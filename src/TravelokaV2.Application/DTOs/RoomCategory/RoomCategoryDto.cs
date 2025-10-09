namespace TravelokaV2.Application.DTOs.RoomCategory
{
    public class RoomCategoryDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public List<string> BasicFacilities { get; set; } = new();
        public List<string> RoomFacilities { get; set; } = new();
        public List<string> BathAmenities { get; set; } = new();

        public string? About { get; set; }

        public Guid? AccomId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public Guid? UpdateBy { get; set; }

        public List<Guid> ImageIds { get; set; } = new();
    }
}