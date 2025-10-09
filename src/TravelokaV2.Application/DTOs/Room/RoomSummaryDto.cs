namespace TravelokaV2.Application.DTOs.Room
{
    public class RoomSummaryDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public bool? Available { get; set; }
        public bool? Breakfast { get; set; }
        public float? Rating { get; set; }

        public Guid? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public Guid? BedTypeId { get; set; }
        public string? BedTypeName { get; set; }
    }
}