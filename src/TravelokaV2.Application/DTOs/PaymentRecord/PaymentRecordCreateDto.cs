using TravelokaV2.Domain.Enums;

namespace TravelokaV2.Application.DTOs.PaymentRecord
{
    public class PaymentRecordCreateDto
    {
        public string? UserId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public Guid? AccomTypeId { get; set; }
        public PaymentStatus? Status { get; set; }
    }
}