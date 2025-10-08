namespace TravelokaV2.Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }
        public string? Alt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifyAt { get; set; }
        public Guid? UpdateBy { get; set; }
        public ICollection<Accom_Image> Accom_Images { get; set; } = new List<Accom_Image>();
        public ICollection<Room_Image> Room_Images { get; set; } = new List<Room_Image>();
    }
}