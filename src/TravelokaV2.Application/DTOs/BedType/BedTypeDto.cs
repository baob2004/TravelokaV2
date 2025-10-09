namespace TravelokaV2.Application.DTOs.BedType
{
    public class BedTypeDto
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public Guid? UpdateBy { get; set; }
    }
}