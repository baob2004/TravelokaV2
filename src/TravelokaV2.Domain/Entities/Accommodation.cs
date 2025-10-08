namespace TravelokaV2.Domain.Entities
{
    public class Accommodation
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Guid? AccomTypeId { get; set; }
        public string? GgMapsQuery { get; set; }
        public string? Ll { get; set; }
        public int? Star { get; set; }
        public float? Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifyAt { get; set; }
        public Guid? UpdateBy { get; set; }

        public AccomType? AccomType { get; set; }
        public ICollection<Accom_Facility> Accom_Facilities { get; set; } = new List<Accom_Facility>();
        public ICollection<Accom_RR> Accom_RRs { get; set; } = new List<Accom_RR>();
        public ICollection<Accom_Image> Accom_Images { get; set; } = new List<Accom_Image>();
        public GeneralInfo? GeneralInfo { get; set; }
        public Policy? Policy { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
    }
}