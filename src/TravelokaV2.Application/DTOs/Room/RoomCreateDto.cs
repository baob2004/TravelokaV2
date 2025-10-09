namespace TravelokaV2.Application.DTOs.Room
{
    public class RoomCreateDto
    {
        public string? Name { get; set; }
        public bool? Breakfast { get; set; }
        public int? NumberOfBeds { get; set; }

        public Guid? BedTypeId { get; set; }
        public Guid? CancelPolicyId { get; set; }
        public Guid? CategoryId { get; set; }

        public bool? Available { get; set; }
        public float? Rating { get; set; }
    }
}