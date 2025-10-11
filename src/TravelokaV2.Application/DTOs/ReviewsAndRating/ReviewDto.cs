namespace TravelokaV2.Application.DTOs.ReviewsAndRating
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public float? Rating { get; set; }
        public string? Review { get; set; }

        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public Guid? AccomId { get; set; }
    }
}