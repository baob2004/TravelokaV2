using TravelokaV2.Application.DTOs.Facility;
using TravelokaV2.Application.DTOs.GeneralInfo;
using TravelokaV2.Application.DTOs.Image;
using TravelokaV2.Application.DTOs.Policy;
using TravelokaV2.Application.DTOs.ReviewsAndRating;
using TravelokaV2.Application.DTOs.RoomCategory;

namespace TravelokaV2.Application.DTOs.Accommodation
{
    public class AccomDetailDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? AccomTypeId { get; set; }
        public string? AccomTypeName { get; set; }

        public int? Star { get; set; }
        public float? Rating { get; set; }
        public string? Description { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
        public string? GgMapsQuery { get; set; }
        public string? Ll { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public Guid? UpdateBy { get; set; }

        public GeneralInfoDto? GeneralInfo { get; set; }
        public PolicyDto? Policy { get; set; }

        public List<FacilityDto> Facilities { get; set; } = new();
        public List<ImageDto> Images { get; set; } = new();

        public List<RoomCategoryDto> RoomCategories { get; set; } = new();
        public List<ReviewDto> Reviews { get; set; } = new();
    }
}