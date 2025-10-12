using TravelokaV2.Application.DTOs.Accommodation;
using TravelokaV2.Application.DTOs.Common;
using TravelokaV2.Application.DTOs.GeneralInfo;
using TravelokaV2.Application.DTOs.Policy;

namespace TravelokaV2.Application.Services
{
    public interface IAccommodationService
    {
        // ==== Accommodation ====
        Task<PagedResult<AccomSummaryDto>> GetPagedAsync(PagedQuery pagedQuery, AccomSearchRequest request, CancellationToken ct);

        Task<AccomDetailDto?> GetByIdAsync(Guid id, CancellationToken ct);

        Task<Guid> CreateAsync(AccomCreateDto dto, CancellationToken ct);
        Task<IReadOnlyList<Guid>> CreateManyAsync(IEnumerable<AccomCreateDto> dtos, CancellationToken ct);

        Task UpdateAsync(Guid id, AccomUpdateDto dto, CancellationToken ct);

        Task DeleteAsync(Guid id, CancellationToken ct);

        // ==== General Info ====
        Task<GeneralInfoDto?> GetGeneralInfoAsync(Guid accomId, CancellationToken ct);
        Task UpsertGeneralInfoAsync(Guid accomId, GeneralInfoUpdateDto dto, CancellationToken ct);
        Task DeleteGeneralInfoAsync(Guid accomId, CancellationToken ct);

        // ==== Policy ====
        Task<PolicyDto?> GetPolicyAsync(Guid accomId, CancellationToken ct);
        Task UpsertPolicyAsync(Guid accomId, PolicyUpdateDto dto, CancellationToken ct);
        Task DeletePolicyAsync(Guid accomId, CancellationToken ct);

        // ==== Assign Image ====
        Task LinkImageAsync(Guid accomId, Guid imageId, CancellationToken ct);
        Task UnlinkImageAsync(Guid accomId, Guid imageId, CancellationToken ct);
        Task<int> LinkImagesAsync(Guid accomId, IEnumerable<Guid> imageIds, CancellationToken ct);

        // ==== Assign Facility ====.
        Task LinkFacilityAsync(Guid accomId, Guid facilityId, CancellationToken ct);
        Task UnlinkFacilityAsync(Guid accomId, Guid facilityId, CancellationToken ct);
        Task<int> LinkFacilitiesAsync(Guid accomId, IEnumerable<Guid> facilityIds, CancellationToken ct);
    }
}