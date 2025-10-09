using TravelokaV2.Domain.Enums;

namespace TravelokaV2.Domain.Entities
{
    public class PaymentRecord
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public Guid? AccomTypeId { get; set; }
        public PaymentStatus? Status { get; set; }
        public Room? Room { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }
}