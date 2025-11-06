using TravelokaV2.Application.DTOs.Accommodation;
using TravelokaV2.Application.DTOs.Common;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Interfaces
{
    public interface IAccommodationRepository : IGenericRepository<Accommodation>
    {
        Task<PagedResult<Accommodation>> GetPagedAsync(PagedQuery pagedQuery,
            AccomSearchRequest request,
            CancellationToken ct);
        Task<GeneralInfo> GetGeneralInfoByAccomIdAsync(Guid accomId, CancellationToken ct);
        Task<Policy> GetPolicyByAccomIdAsync(Guid accomId, CancellationToken ct);
        Task<Accom_Image> GetAccom_ImageAsync(Guid accomId, Guid imageId);
        Task<Accom_Facility> GetAccom_FacilityAsync(Guid accomId, Guid facilityId);
        Task<Accommodation?> GetDetailsByIdAsync(Guid id, CancellationToken ct);
    }
}