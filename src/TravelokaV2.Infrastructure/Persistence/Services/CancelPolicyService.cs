using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.CancelPolicy;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Services
{
    public class CancelPolicyService : ICancelPolicyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CancelPolicyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CancelPolicyDto>> GetAllAsync(CancellationToken ct)
        {
            var list = await _uow.CancelPolicies.Query()
                .AsNoTracking()
                .OrderBy(x => x.Type)
                .ToListAsync(ct);

            return _mapper.Map<List<CancelPolicyDto>>(list);
        }

        public async Task<CancelPolicyDto> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.CancelPolicies.GetByIdAsync(id, ct: ct)
                ?? throw new KeyNotFoundException("CancelPolicy not found.");

            return _mapper.Map<CancelPolicyDto>(entity);
        }

        public async Task<Guid> CreateAsync(CancelPolicyCreateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Type)) throw new ArgumentException("Type is required.", nameof(dto.Type));

            var dup = await _uow.CancelPolicies.Query()
                .AnyAsync(x => x.Type == dto.Type, ct);
            if (dup) throw new InvalidOperationException("CancelPolicy already exists.");

            var entity = _mapper.Map<CancelPolicy>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _uow.CancelPolicies.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, CancelPolicyUpdateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Type)) throw new ArgumentException("Type is required.", nameof(dto.Type));

            var entity = await _uow.CancelPolicies.GetByIdAsync(id, asNoTracking: false, ct: ct)
                ?? throw new KeyNotFoundException("CancelPolicy not found.");

            var dup = await _uow.CancelPolicies.Query()
                .AnyAsync(x => x.Id != id && x.Type == dto.Type, ct);
            if (dup) throw new InvalidOperationException("Another CancelPolicy with same name exists.");

            _mapper.Map(dto, entity);
            entity.ModifyAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.CancelPolicies.GetByIdAsync(id, asNoTracking: false, ct: ct)
                ?? throw new KeyNotFoundException("CancelPolicy not found.");

            _uow.CancelPolicies.Remove(entity);
            await _uow.SaveChangesAsync(ct);
        }
    }
}
