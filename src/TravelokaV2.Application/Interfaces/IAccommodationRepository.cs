using TravelokaV2.Application.DTOs.Accommodation;
using TravelokaV2.Application.DTOs.Common;
using TravelokaV2.Domain.Entities;

namespace TravelokaV2.Application.Interfaces
{
    public interface IAccommodationRepository : IGenericRepository<Accommodation>
    {
        Task<PagedResult<Accommodation>> GetPaged(PagedQuery pagedQuery,
            AccomSearchRequest request,
            CancellationToken ct);
        Task<GeneralInfo> GetGeneralInfoByAccomId(Guid accomId, CancellationToken ct);
        Task<Policy> GetPolicyByAccomId(Guid accomId, CancellationToken ct);
        Task<Accom_Image> GetAccom_Image(Guid accomId, Guid imageId);
        Task<Accom_Facility> GetAccom_Facility(Guid accomId, Guid facilityId);
    }
}