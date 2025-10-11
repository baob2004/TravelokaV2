using TravelokaV2.Application.DTOs.ReviewsAndRating;

namespace TravelokaV2.Application.Services
{
    public interface IReviewsService
    {
        Task<ReviewDto?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<ReviewDto>> GetByAccommodationAsync(Guid accomId, CancellationToken ct);
        Task<Guid> CreateAsync(Guid accomId, ReviewCreateDto dto, CancellationToken ct);
        Task UpdateAsync(Guid id, ReviewUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}