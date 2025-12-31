using TravelokaV2.Application.DTOs.AccomType;

namespace TravelokaV2.Application.Services
{
    public interface IAccomTypeService
    {
        Task<IEnumerable<AccomTypeDto>> GetAllAsync(CancellationToken ct);
        Task<AccomTypeDto?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<Guid> CreateAsync(AccomTypeCreateDto dto, CancellationToken ct);
        Task UpdateAsync(Guid id, AccomTypeUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}