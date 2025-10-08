namespace TravelokaV2.Domain.Entities
{
    public class Facility
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifyAt { get; set; }
        public Guid? UpdateBy { get; set; }
        public ICollection<Accom_Facility> Accom_Facilities { get; set; } = new List<Accom_Facility>();
    }
}