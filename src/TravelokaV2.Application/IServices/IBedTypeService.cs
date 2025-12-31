using TravelokaV2.Application.DTOs.BedType;

namespace TravelokaV2.Application.Services
{
    public interface IBedTypeService
    {
        Task<IEnumerable<BedTypeDto>> GetAllAsync(CancellationToken ct);
        Task<BedTypeDto> GetByIdAsync(Guid id, CancellationToken ct);
        Task<Guid> CreateAsync(BedTypeCreateDto dto, CancellationToken ct);
        Task UpdateAsync(Guid id, BedTypeUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}