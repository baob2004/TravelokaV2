using TravelokaV2.Application.DTOs.PaymentRecord;
using static TravelokaV2.Application.DTOs.ReviewsAndRating.BulkPayment;

namespace TravelokaV2.Application.Services
{
    public interface IPaymentRecordService
    {
        Task<IEnumerable<PaymentRecordDto>> GetAllAsync(CancellationToken ct);
        Task<PaymentRecordDto> GetByIdAsync(Guid id, CancellationToken ct);
        Task<Guid> CreateAsync(PaymentRecordCreateDto dto, string currentUserId, CancellationToken ct);
        Task UpdateAsync(Guid id, PaymentRecordUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<PaymentRecordDto>> GetByUserIdAsync(string userId, CancellationToken ct);
        Task<BulkPaymentRecordCreateResponse> BulkCreateAsync(BulkPaymentRecordCreateRequest req, CancellationToken ct);

    }
}