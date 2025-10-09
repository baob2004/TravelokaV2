namespace TravelokaV2.Domain.Entities
{
    public class RoomCategory
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<string> BasicFacilities { get; set; } = new List<string>();
        public ICollection<string> RoomFacilities { get; set; } = new List<string>();
        public ICollection<string> BathAmenities { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifyAt { get; set; }
        public Guid? UpdateBy { get; set; }
        public string? About { get; set; }
        public Guid? AccomId { get; set; }
        public Accommodation? Accommodation { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<Room_Image> Room_Images { get; set; } = new List<Room_Image>();
        public ICollection<Room_Facility> Room_Facilities { get; set; } = new List<Room_Facility>();
    }
}