using TravelokaV2.Domain.Enums;

namespace TravelokaV2.Application.DTOs.PaymentRecord
{
    public class PaymentRecordCreateDto
    {
        public Guid? RoomId { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public PaymentStatus? Status { get; set; }
    }
}