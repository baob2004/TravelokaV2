namespace TravelokaV2.Application.DTOs.GeneralInfo
{
    public class GeneralInfoDto
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
    }
}