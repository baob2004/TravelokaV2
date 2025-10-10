using TravelokaV2.Application.DTOs.Facility;
using TravelokaV2.Application.DTOs.Image;
using TravelokaV2.Application.DTOs.Room;

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
        public string? UpdateBy { get; set; }

        public List<ImageDto> Images { get; set; } = new();
        public List<FacilityDto> Facilities { get; set; } = new();
        public List<RoomSummaryDto> Rooms { get; set; } = new();
    }
}