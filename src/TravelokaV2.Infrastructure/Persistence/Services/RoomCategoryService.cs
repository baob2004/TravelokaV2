using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.RoomCategory;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Services
{
    public class RoomCategoryService : IRoomCategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RoomCategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<RoomCategoryDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var rc = await _uow.RoomCategories.GetByIdAsync(
                id,
                asNoTracking: true,
                ct: ct,
                q => q.Include(x => x.Room_Images).ThenInclude(ri => ri.Image)!,
                q => q.Include(x => x.Room_Facilities).ThenInclude(rf => rf.Facility)!,
                q => q.Include(x => x.Rooms)
            );
            if (rc == null) throw new KeyNotFoundException("RoomCategory not found.");
            return _mapper.Map<RoomCategoryDto>(rc);
        }

        public async Task<IEnumerable<RoomCategoryDto>> GetByAccommodationAsync(Guid accomId, CancellationToken ct)
        {
            var exists = await _uow.Accommodations.Query().AnyAsync(a => a.Id == accomId, ct);
            if (!exists) throw new KeyNotFoundException("Accommodation not found.");

            var list = await _uow.RoomCategories.Query()
                .AsNoTracking()
                .Where(rc => rc.AccomId == accomId)
                .Include(x => x.Room_Images).ThenInclude(ri => ri.Image)
                .Include(x => x.Room_Facilities).ThenInclude(rf => rf.Facility)
                .Include(x => x.Rooms)
                .OrderBy(rc => rc.Name)
                .ToListAsync(ct);

            return _mapper.Map<List<RoomCategoryDto>>(list);
        }

        public async Task<Guid> CreateAsync(RoomCategoryCreateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new ArgumentException("Name is required.", nameof(dto.Name));

            if (dto.AccomId.HasValue)
            {
                var ok = await _uow.Accommodations.Query().AnyAsync(a => a.Id == dto.AccomId, ct);
                if (!ok) throw new KeyNotFoundException("Accommodation not found.");
            }

            var entity = _mapper.Map<RoomCategory>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _uow.RoomCategories.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, RoomCategoryUpdateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new ArgumentException("Name is required.", nameof(dto.Name));

            var entity = await _uow.RoomCategories.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("RoomCategory not found.");

            if (dto.AccomId.HasValue && dto.AccomId != entity.AccomId)
            {
                var ok = await _uow.Accommodations.Query().AnyAsync(a => a.Id == dto.AccomId, ct);
                if (!ok) throw new KeyNotFoundException("Accommodation not found.");
            }

            _mapper.Map(dto, entity);
            entity.ModifyAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.RoomCategories.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("RoomCategory not found.");

            _uow.RoomCategories.Remove(entity);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task LinkFacilityAsync(Guid roomCategoryId, Guid facilityId, CancellationToken ct)
        {
            var rcExists = await _uow.RoomCategories.Query().AnyAsync(x => x.Id == roomCategoryId, ct);
            if (!rcExists) throw new KeyNotFoundException("RoomCategory not found.");

            var facExists = await _uow.Facilities.Query().AnyAsync(f => f.Id == facilityId, ct);
            if (!facExists) throw new KeyNotFoundException("Facility not found.");

            var exists = await _uow.RoomFacilities.Query()
                .AnyAsync(x => x.RoomCategoryId == roomCategoryId && x.FacilityId == facilityId, ct);
            if (exists) return;

            await _uow.RoomFacilities.AddAsync(new Room_Facility
            {
                Id = Guid.NewGuid(),
                RoomCategoryId = roomCategoryId,
                FacilityId = facilityId
            }, ct);

            await _uow.SaveChangesAsync(ct);
        }

        public async Task UnlinkFacilityAsync(Guid roomCategoryId, Guid facilityId, CancellationToken ct)
        {
            var link = await _uow.RoomFacilities.Query()
                .FirstOrDefaultAsync(x => x.RoomCategoryId == roomCategoryId && x.FacilityId == facilityId, ct);

            if (link == null) throw new KeyNotFoundException("Facility link not found.");

            _uow.RoomFacilities.Remove(link);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task<int> LinkFacilitiesAsync(Guid roomCategoryId, IEnumerable<Guid> facilityIds, CancellationToken ct)
        {
            if (facilityIds is null) throw new ArgumentNullException(nameof(facilityIds));
            var ids = facilityIds.Where(x => x != Guid.Empty).Distinct().ToList();
            if (ids.Count == 0) return 0;

            var rcExists = await _uow.RoomCategories.Query().AnyAsync(x => x.Id == roomCategoryId, ct);
            if (!rcExists) throw new KeyNotFoundException("RoomCategory not found.");

            var existFacIds = await _uow.Facilities.Query()
                .Where(f => ids.Contains(f.Id))
                .Select(f => f.Id)
                .ToListAsync(ct);
            var missing = ids.Except(existFacIds).ToList();
            if (missing.Count > 0) throw new KeyNotFoundException("One or more facilities not found.");

            var already = await _uow.RoomFacilities.Query()
                .Where(rf => rf.RoomCategoryId == roomCategoryId && ids.Contains(rf.FacilityId))
                .Select(rf => rf.FacilityId)
                .ToListAsync(ct);

            var toAdd = ids.Except(already).ToList();
            foreach (var id in toAdd)
            {
                await _uow.RoomFacilities.AddAsync(new Room_Facility
                {
                    Id = Guid.NewGuid(),
                    RoomCategoryId = roomCategoryId,
                    FacilityId = id
                }, ct);
            }

            if (toAdd.Count > 0) await _uow.SaveChangesAsync(ct);
            return toAdd.Count;
        }

        public async Task LinkImageAsync(Guid roomCategoryId, Guid imageId, CancellationToken ct)
        {
            var rcExists = await _uow.RoomCategories.Query().AnyAsync(x => x.Id == roomCategoryId, ct);
            if (!rcExists) throw new KeyNotFoundException("RoomCategory not found.");

            var imgExists = await _uow.Images.Query().AnyAsync(i => i.Id == imageId, ct);
            if (!imgExists) throw new KeyNotFoundException("Image not found.");

            var exists = await _uow.RoomImages.Query()
                .AnyAsync(x => x.RoomCategoryId == roomCategoryId && x.ImageId == imageId, ct);
            if (exists) return;

            await _uow.RoomImages.AddAsync(new Room_Image
            {
                Id = Guid.NewGuid(),
                RoomCategoryId = roomCategoryId,
                ImageId = imageId
            }, ct);

            await _uow.SaveChangesAsync(ct);
        }

        public async Task UnlinkImageAsync(Guid roomCategoryId, Guid imageId, CancellationToken ct)
        {
            var link = await _uow.RoomImages.Query()
                .FirstOrDefaultAsync(x => x.RoomCategoryId == roomCategoryId && x.ImageId == imageId, ct);

            if (link == null) throw new KeyNotFoundException("Image link not found.");

            _uow.RoomImages.Remove(link);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task<int> LinkImagesAsync(Guid roomCategoryId, IEnumerable<Guid> imageIds, CancellationToken ct)
        {
            if (imageIds is null) throw new ArgumentNullException(nameof(imageIds));
            var ids = imageIds.Where(x => x != Guid.Empty).Distinct().ToList();
            if (ids.Count == 0) return 0;

            var rcExists = await _uow.RoomCategories.Query().AnyAsync(x => x.Id == roomCategoryId, ct);
            if (!rcExists) throw new KeyNotFoundException("RoomCategory not found.");

            var existImgIds = await _uow.Images.Query()
                .Where(i => ids.Contains(i.Id))
                .Select(i => i.Id)
                .ToListAsync(ct);
            var missing = ids.Except(existImgIds).ToList();
            if (missing.Count > 0) throw new KeyNotFoundException("One or more images not found.");

            var already = await _uow.RoomImages.Query()
                .Where(ri => ri.RoomCategoryId == roomCategoryId && ids.Contains(ri.ImageId))
                .Select(ri => ri.ImageId)
                .ToListAsync(ct);

            var toAdd = ids.Except(already).ToList();
            foreach (var id in toAdd)
            {
                await _uow.RoomImages.AddAsync(new Room_Image
                {
                    Id = Guid.NewGuid(),
                    RoomCategoryId = roomCategoryId,
                    ImageId = id
                }, ct);
            }

            if (toAdd.Count > 0) await _uow.SaveChangesAsync(ct);
            return toAdd.Count;
        }

        public async Task<IReadOnlyList<Guid>> CreateManyAsync(IEnumerable<RoomCategoryCreateDto> dtos, CancellationToken ct)
        {
            if (dtos is null) throw new ArgumentNullException(nameof(dtos));
            var inputs = dtos.ToList();
            if (inputs.Count == 0) return Array.Empty<Guid>();

            foreach (var d in inputs)
                if (string.IsNullOrWhiteSpace(d.Name))
                    throw new ArgumentException("Name is required.", nameof(d.Name));

            var accomIds = inputs.Where(x => x.AccomId.HasValue)
                                 .Select(x => x.AccomId!.Value)
                                 .Distinct()
                                 .ToList();

            if (accomIds.Count > 0)
            {
                var existingAccomIds = await _uow.Accommodations.Query()
                    .Where(a => accomIds.Contains(a.Id))
                    .Select(a => a.Id)
                    .ToListAsync(ct);

                var missing = accomIds.Except(existingAccomIds).ToList();
                if (missing.Count > 0)
                    throw new KeyNotFoundException("One or more Accommodation not found.");
            }

            // Chống trùng theo (Name, AccomId)
            var pairs = inputs
                .Where(x => x.AccomId.HasValue)
                .Select(x => new { x.Name, x.AccomId!.Value })
                .ToList();

            if (pairs.Count > 0)
            {
                var dupDb = await _uow.RoomCategories.Query()
                    .Where(rc => rc.AccomId != null &&
                                 pairs.Select(p => p.Value).Contains(rc.AccomId.Value) &&
                                 pairs.Select(p => p.Name).Contains(rc.Name!))
                    .Select(rc => new { rc.Name, rc.AccomId })
                    .ToListAsync(ct);

                // nếu không muốn chặn trùng DB thì có thể bỏ khối này
                if (dupDb.Any())
                    throw new InvalidOperationException("Some RoomCategories already exist for given accommodation(s).");
            }

            var now = DateTime.UtcNow;
            var entities = inputs.Select(d =>
            {
                var e = _mapper.Map<RoomCategory>(d);
                e.CreatedAt = now;
                return e;
            }).ToList();

            foreach (var e in entities)
                await _uow.RoomCategories.AddAsync(e, ct);

            await _uow.SaveChangesAsync(ct);
            return entities.Select(e => e.Id).ToList();
        }
    }
}
