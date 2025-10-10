namespace TravelokaV2.Application.DTOs.Room
{
    public class RoomDetailDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public bool? Breakfast { get; set; }
        public int? NumberOfBeds { get; set; }
        public bool? Available { get; set; }
        public float? Rating { get; set; }

        public Guid? BedTypeId { get; set; }
        public string? BedTypeName { get; set; }

        public Guid? CancelPolicyId { get; set; }
        public string? CancelPolicyName { get; set; }   // tuỳ bạn có trường Name/Title trong CancelPolicy

        public Guid? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public string? UpdateBy { get; set; }
    }
}