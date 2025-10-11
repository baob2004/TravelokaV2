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
    }
}
