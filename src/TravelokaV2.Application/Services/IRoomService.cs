using TravelokaV2.Application.DTOs.Room;

namespace TravelokaV2.Application.Services
{
    public interface IRoomService
    {
        Task<RoomDetailDto> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<RoomSummaryDto>> GetByCategoryAsync(Guid categoryId, CancellationToken ct);

        Task<Guid> CreateAsync(RoomCreateDto dto, CancellationToken ct);
        Task UpdateAsync(Guid id, RoomUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);

        Task<IReadOnlyList<Guid>> CreateManyAsync(IEnumerable<RoomCreateDto> dtos, CancellationToken ct);
    }
}