using TravelokaV2.Application.DTOs.Facility;

namespace TravelokaV2.Application.Services
{
    public interface IFacilityService
    {
        Task<IEnumerable<FacilityDto>> GetAllAsync(CancellationToken ct);
        Task<FacilityDto?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<Guid> CreateAsync(FacilityCreateDto dto, CancellationToken ct);
        Task UpdateAsync(Guid id, FacilityUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);

        Task<IReadOnlyList<Guid>> CreateManyAsync(IEnumerable<FacilityCreateDto> dtos, CancellationToken ct);
    }
}