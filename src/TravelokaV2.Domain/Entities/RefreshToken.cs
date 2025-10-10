namespace TravelokaV2.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; } = default!;
        public string Token { get; set; } = default!;
        public DateTime ExpiresAtUtc { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}