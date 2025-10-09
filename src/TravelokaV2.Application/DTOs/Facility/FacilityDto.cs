namespace TravelokaV2.Application.DTOs.Facility
{
    public class FacilityDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public Guid? UpdateBy { get; set; }
    }
}