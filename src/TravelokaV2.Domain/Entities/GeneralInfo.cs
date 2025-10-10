using TravelokaV2.Domain.Abstractions;

namespace TravelokaV2.Domain.Entities
{
    public class GeneralInfo : ISoftDelete
    {
        public Guid AccomId { get; set; }
        public string? PopularFacility { get; set; }
        public TimeOnly? CheckOut { get; set; }
        public TimeOnly? CheckIn { get; set; }
        public string? DistanceToDowntown { get; set; }
        public string? PopularInArea { get; set; }
        public bool? BreakfastAvailability { get; set; }
        public int? AvailableRooms { get; set; }
        public int? NumberOfFloors { get; set; }
        public string? AnotherFacility { get; set; }
        public string? NearbyPOI { get; set; }
        public Accommodation Accommodation { get; set; } = default!;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}