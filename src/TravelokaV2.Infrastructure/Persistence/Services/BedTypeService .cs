// Application/Services/BedTypeService.cs
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.BedType;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Services
{
    public class BedTypeService : IBedTypeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BedTypeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BedTypeDto>> GetAllAsync(CancellationToken ct)
        {
            var list = await _uow.BedTypes.Query()
                .AsNoTracking()
                .OrderBy(x => x.Type)
                .ToListAsync(ct);

            return _mapper.Map<List<BedTypeDto>>(list);
        }

        public async Task<BedTypeDto> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.BedTypes.GetByIdAsync(id, ct: ct)
                ?? throw new KeyNotFoundException("BedType not found.");

            return _mapper.Map<BedTypeDto>(entity);
        }

        public async Task<Guid> CreateAsync(BedTypeCreateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Type)) throw new ArgumentException("Type is required.", nameof(dto.Type));

            var dup = await _uow.BedTypes.Query()
                .AnyAsync(x => x.Type == dto.Type, ct);
            if (dup) throw new InvalidOperationException("BedType already exists.");

            var entity = _mapper.Map<BedType>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _uow.BedTypes.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, BedTypeUpdateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Type)) throw new ArgumentException("Type is required.", nameof(dto.Type));

            var entity = await _uow.BedTypes.GetByIdAsync(id, asNoTracking: false, ct: ct)
                ?? throw new KeyNotFoundException("BedType not found.");

            var dup = await _uow.BedTypes.Query()
                .AnyAsync(x => x.Id != id && x.Type == dto.Type, ct);
            if (dup) throw new InvalidOperationException("Another BedType with same name exists.");

            _mapper.Map(dto, entity);
            entity.ModifyAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.BedTypes.GetByIdAsync(id, asNoTracking: false, ct: ct)
                ?? throw new KeyNotFoundException("BedType not found.");

            _uow.BedTypes.Remove(entity);
            await _uow.SaveChangesAsync(ct);
        }
    }
}
