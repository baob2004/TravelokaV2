using TravelokaV2.Application.DTOs.Accommodation;
using TravelokaV2.Application.DTOs.Common;

namespace TravelokaV2.Application.Services
{
    public interface IAccommodationService
    {
        Task<PagedResult<AccomSummaryDto>> GetPagedAsync(PagedQuery pagedQuery, AccomSearchRequest request, CancellationToken ct);

        Task<AccomDetailDto?> GetByIdAsync(Guid id, CancellationToken ct);

        Task<Guid> CreateAsync(AccomCreateDto dto, CancellationToken ct);

        Task UpdateAsync(Guid id, AccomUpdateDto dto, CancellationToken ct);

        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}