namespace TravelokaV2.Application.DTOs.Image
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }
        public string? Alt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public string? UpdateBy { get; set; }
    }
}