using TravelokaV2.Application.DTOs.PaymentRecord;

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
    }
}