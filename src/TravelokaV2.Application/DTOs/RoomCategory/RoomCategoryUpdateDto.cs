namespace TravelokaV2.Application.DTOs.RoomCategory
{
    public class RoomCategoryUpdateDto
    {
        public string? Name { get; set; }
        public List<string>? BasicFacilities { get; set; }
        public List<string>? RoomFacilities { get; set; }
        public List<string>? BathAmenities { get; set; }
        public string? About { get; set; }
        public Guid? AccomId { get; set; }
    }
}