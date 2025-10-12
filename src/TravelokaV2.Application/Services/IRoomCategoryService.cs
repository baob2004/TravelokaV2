using TravelokaV2.Application.DTOs.RoomCategory;

namespace TravelokaV2.Application.Services
{
    public interface IRoomCategoryService
    {
        Task<RoomCategoryDto?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<RoomCategoryDto>> GetByAccommodationAsync(Guid accomId, CancellationToken ct);
        Task<Guid> CreateAsync(RoomCategoryCreateDto dto, CancellationToken ct);
        Task UpdateAsync(Guid id, RoomCategoryUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);

        Task LinkFacilityAsync(Guid roomCategoryId, Guid facilityId, CancellationToken ct);
        Task UnlinkFacilityAsync(Guid roomCategoryId, Guid facilityId, CancellationToken ct);

        Task LinkImageAsync(Guid roomCategoryId, Guid imageId, CancellationToken ct);
        Task UnlinkImageAsync(Guid roomCategoryId, Guid imageId, CancellationToken ct);

        Task<IReadOnlyList<Guid>> CreateManyAsync(IEnumerable<RoomCategoryCreateDto> dtos, CancellationToken ct);
    }
}