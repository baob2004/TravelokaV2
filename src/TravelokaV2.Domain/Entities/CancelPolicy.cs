namespace TravelokaV2.Domain.Entities
{
    public class CancelPolicy
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifyAt { get; set; }
        public string? UpdateBy { get; set; }
    }
}