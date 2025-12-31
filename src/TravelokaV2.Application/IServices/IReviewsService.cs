using TravelokaV2.Application.DTOs.ReviewsAndRating;
using static TravelokaV2.Application.DTOs.ReviewsAndRating.BulkReview;

namespace TravelokaV2.Application.Services
{
    public interface IReviewsService
    {
        Task<ReviewDto?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<ReviewDto>> GetByAccommodationAsync(Guid accomId, CancellationToken ct);
        Task<Guid> CreateAsync(Guid accomId, ReviewCreateDto dto, string currentUserId, string? currentUserName, CancellationToken ct);
        Task UpdateAsync(Guid id, ReviewUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);

        Task<BulkReviewCreateResponse> BulkCreateAsync(Guid accomId, BulkReviewCreateRequest req, CancellationToken ct);
    }
}