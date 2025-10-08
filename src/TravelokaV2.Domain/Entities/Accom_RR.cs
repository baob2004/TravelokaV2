namespace TravelokaV2.Domain.Entities
{
    public class Accom_RR
    {
        public Guid Id { get; set; }
        public Guid AccomId { get; set; }
        public Guid RRId { get; set; }
        public Accommodation? Accommodation { get; set; }
        public ReviewsAndRating? ReviewsAndRating { get; set; }
    }
}