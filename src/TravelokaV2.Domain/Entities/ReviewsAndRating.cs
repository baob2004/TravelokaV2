using TravelokaV2.Domain.Abstractions;

namespace TravelokaV2.Domain.Entities
{
    public class ReviewsAndRating : ISoftDelete
    {
        public Guid Id { get; set; }
        public float? Rating { get; set; }
        public string? Review { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public string? UserId { get; set; }
        public ICollection<Accom_RR> Accom_RRs { get; set; } = new List<Accom_RR>();
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}