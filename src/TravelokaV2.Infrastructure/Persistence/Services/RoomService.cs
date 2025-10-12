using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.Room;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<RoomDetailDto> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var room = await _uow.Rooms.GetByIdAsync(
                id, asNoTracking: true, ct: ct,
                q => q.Include(r => r.BedType)!,
                q => q.Include(r => r.CancelPolicy)!,
                q => q.Include(r => r.RoomCategory)!
            ) ?? throw new KeyNotFoundException("Room not found.");

            return _mapper.Map<RoomDetailDto>(room);
        }

        public async Task<IEnumerable<RoomSummaryDto>> GetByCategoryAsync(Guid categoryId, CancellationToken ct)
        {
            var exists = await _uow.RoomCategories.Query().AnyAsync(rc => rc.Id == categoryId, ct);
            if (!exists) throw new KeyNotFoundException("Room category not found.");

            var rooms = await _uow.Rooms.Query()
                .AsNoTracking()
                .Where(r => r.CategoryId == categoryId)
                .Include(r => r.BedType)
                .Include(r => r.RoomCategory)
                .OrderBy(r => r.Name)
                .ToListAsync(ct);

            return _mapper.Map<List<RoomSummaryDto>>(rooms);
        }

        public async Task<Guid> CreateAsync(RoomCreateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new ArgumentException("Name is required.", nameof(dto.Name));

            if (dto.CategoryId.HasValue &&
                !await _uow.RoomCategories.Query().AnyAsync(x => x.Id == dto.CategoryId, ct))
                throw new KeyNotFoundException("Room category not found.");

            if (dto.BedTypeId.HasValue &&
                !await _uow.BedTypes.Query().AnyAsync(x => x.Id == dto.BedTypeId, ct))
                throw new KeyNotFoundException("Bed type not found.");

            if (dto.CancelPolicyId.HasValue &&
                !await _uow.CancelPolicies.Query().AnyAsync(x => x.Id == dto.CancelPolicyId, ct))
                throw new KeyNotFoundException("Cancel policy not found.");

            var entity = _mapper.Map<Room>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _uow.Rooms.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, RoomUpdateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new ArgumentException("Name is required.", nameof(dto.Name));

            var entity = await _uow.Rooms.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("Room not found.");

            if (dto.CategoryId.HasValue && dto.CategoryId != entity.CategoryId &&
                !await _uow.RoomCategories.Query().AnyAsync(x => x.Id == dto.CategoryId, ct))
                throw new KeyNotFoundException("Room category not found.");

            if (dto.BedTypeId.HasValue && dto.BedTypeId != entity.BedTypeId &&
                !await _uow.BedTypes.Query().AnyAsync(x => x.Id == dto.BedTypeId, ct))
                throw new KeyNotFoundException("Bed type not found.");

            if (dto.CancelPolicyId.HasValue && dto.CancelPolicyId != entity.CancelPolicyId &&
                !await _uow.CancelPolicies.Query().AnyAsync(x => x.Id == dto.CancelPolicyId, ct))
                throw new KeyNotFoundException("Cancel policy not found.");

            _mapper.Map(dto, entity);
            entity.ModifyAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.Rooms.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("Room not found.");

            _uow.Rooms.Remove(entity);
            await _uow.SaveChangesAsync(ct);
        }

        public async Task<IReadOnlyList<Guid>> CreateManyAsync(IEnumerable<RoomCreateDto> dtos, CancellationToken ct)
        {
            if (dtos is null) throw new ArgumentNullException(nameof(dtos));
            var items = dtos.ToList();
            if (items.Count == 0) return Array.Empty<Guid>();

            foreach (var d in items)
                if (string.IsNullOrWhiteSpace(d.Name))
                    throw new ArgumentException("Name is required.");

            var categoryIds = items.Where(x => x.CategoryId.HasValue)
                                   .Select(x => x.CategoryId!.Value)
                                   .Distinct()
                                   .ToList();
            if (categoryIds.Count > 0)
            {
                var exist = await _uow.RoomCategories.Query()
                    .Where(rc => categoryIds.Contains(rc.Id))
                    .Select(rc => rc.Id)
                    .ToListAsync(ct);
                var missing = categoryIds.Except(exist).ToList();
                if (missing.Count > 0) throw new KeyNotFoundException("One or more RoomCategory not found.");
            }

            var bedTypeIds = items.Where(x => x.BedTypeId.HasValue)
                                  .Select(x => x.BedTypeId!.Value)
                                  .Distinct()
                                  .ToList();
            if (bedTypeIds.Count > 0)
            {
                var exist = await _uow.BedTypes.Query()
                    .Where(b => bedTypeIds.Contains(b.Id))
                    .Select(b => b.Id)
                    .ToListAsync(ct);
                var missing = bedTypeIds.Except(exist).ToList();
                if (missing.Count > 0) throw new KeyNotFoundException("One or more BedType not found.");
            }

            var cancelIds = items.Where(x => x.CancelPolicyId.HasValue)
                                 .Select(x => x.CancelPolicyId!.Value)
                                 .Distinct()
                                 .ToList();
            if (cancelIds.Count > 0)
            {
                var exist = await _uow.CancelPolicies.Query()
                    .Where(c => cancelIds.Contains(c.Id))
                    .Select(c => c.Id)
                    .ToListAsync(ct);
                var missing = cancelIds.Except(exist).ToList();
                if (missing.Count > 0) throw new KeyNotFoundException("One or more CancelPolicy not found.");
            }

            var now = DateTime.UtcNow;
            var entities = items.Select(d =>
            {
                var e = _mapper.Map<Room>(d);
                e.CreatedAt = now;
                return e;
            }).ToList();

            foreach (var e in entities)
                await _uow.Rooms.AddAsync(e, ct);

            await _uow.SaveChangesAsync(ct);
            return entities.Select(e => e.Id).ToList();
        }
    }
}
