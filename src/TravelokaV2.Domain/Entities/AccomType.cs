namespace TravelokaV2.Domain.Entities
{
    public class AccomType
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifyAt { get; set; }
        public Guid? UpdateBy { get; set; }
        public ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
    }
}