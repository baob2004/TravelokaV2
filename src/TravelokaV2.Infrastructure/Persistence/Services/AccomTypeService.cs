using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.AccomType;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Services
{
    public class AccomTypeService : IAccomTypeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AccomTypeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccomTypeDto>> GetAllAsync(CancellationToken ct)
        {
            var entities = await _uow.AccomTypes.GetAllAsync(ct: ct);
            return _mapper.Map<IEnumerable<AccomTypeDto>>(entities);
        }

        public async Task<AccomTypeDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.AccomTypes.GetByIdAsync(id, ct: ct);
            if (entity == null) throw new KeyNotFoundException("AccomType not found.");
            return _mapper.Map<AccomTypeDto>(entity);
        }

        public async Task<Guid> CreateAsync(AccomTypeCreateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Type))
                throw new ArgumentException("Type is required.", nameof(dto.Type));

            var exists = await _uow.AccomTypes.AnyAsync(x => x.Type == dto.Type, ct);
            if (exists) throw new InvalidOperationException("AccomType already exists.");

            var entity = _mapper.Map<AccomType>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _uow.AccomTypes.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, AccomTypeUpdateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Type))
                throw new ArgumentException("Type is required.", nameof(dto.Type));

            var entity = await _uow.AccomTypes.GetByIdAsync(id, asNoTracking: false, ct: ct)
                        ?? throw new KeyNotFoundException("AccomType not found.");

            var duplicate = await _uow.AccomTypes.AnyAsync(x => x.Id != id && x.Type == dto.Type, ct);
            if (duplicate) throw new InvalidOperationException("Another AccomType with the same name exists.");

            _mapper.Map(dto, entity);
            entity.ModifyAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var inUse = await _uow.Accommodations.AnyAsync(a => a.AccomTypeId == id, ct);
            if (inUse) throw new InvalidOperationException("AccomType is in use by accommodations.");
            var entity = await _uow.AccomTypes.GetByIdAsync(id, asNoTracking: false, ct: ct)
                         ?? throw new KeyNotFoundException("AccomType not found.");
            _uow.AccomTypes.Remove(entity);
            await _uow.SaveChangesAsync(ct);
        }

    }
}
