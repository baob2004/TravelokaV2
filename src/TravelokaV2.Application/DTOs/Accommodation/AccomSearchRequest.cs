namespace TravelokaV2.Application.DTOs.Accommodation
{
    public class AccomSearchRequest
    {
        public string? Q { get; set; }
        public Guid? AccomTypeId { get; set; }
        public int? StarMin { get; set; }
        public float? RatingMin { get; set; }
    }
}