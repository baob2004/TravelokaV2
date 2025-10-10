namespace TravelokaV2.Application.DTOs.CancelPolicy
{
    public class CancelPolicyDto
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public string? UpdateBy { get; set; }
    }
}