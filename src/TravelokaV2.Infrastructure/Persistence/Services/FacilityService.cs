using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.Facility;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FacilityService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FacilityDto>> GetAllAsync(CancellationToken ct)
        {
            var entities = await _uow.Facilities.GetAllAsync();

            return _mapper.Map<IEnumerable<FacilityDto>>(entities);
        }

        public async Task<FacilityDto?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.Facilities.GetByIdAsync(id, ct: ct)
                        ?? throw new KeyNotFoundException("Facility not found.");
            return _mapper.Map<FacilityDto>(entity);
        }

        public async Task<Guid> CreateAsync(FacilityCreateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Name is required.", nameof(dto.Name));

            var duplicate = await _uow.Facilities.Query()
                .AnyAsync(x => x.Name == dto.Name, ct);
            if (duplicate) throw new InvalidOperationException("Facility name already exists.");

            var entity = _mapper.Map<Facility>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await _uow.Facilities.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, FacilityUpdateDto dto, CancellationToken ct)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Name is required.", nameof(dto.Name));

            var entity = await _uow.Facilities.GetByIdAsync(id, asNoTracking: false, ct: ct)
                        ?? throw new KeyNotFoundException("Facility not found.");

            var duplicate = await _uow.Facilities.Query()
                .AnyAsync(x => x.Id != id && x.Name == dto.Name, ct);
            if (duplicate) throw new InvalidOperationException("Another facility with the same name exists.");

            _mapper.Map(dto, entity);
            entity.ModifyAt = DateTime.UtcNow;

            await _uow.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _uow.Facilities.GetByIdAsync(id, asNoTracking: false, ct: ct)
                        ?? throw new KeyNotFoundException("Facility not found.");

            _uow.Facilities.Remove(entity); // soft delete nếu entity implement ISoftDelete
            await _uow.SaveChangesAsync(ct);
        }
    }
}
