using TravelokaV2.Application.DTOs.PaymentMethod;

namespace TravelokaV2.Application.Services
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethodDto>> GetAllAsync(CancellationToken ct);
        Task<PaymentMethodDto> GetByIdAsync(Guid id, CancellationToken ct);
        Task<Guid> CreateAsync(PaymentMethodCreateDto dto, CancellationToken ct);
        Task UpdateAsync(Guid id, PaymentMethodUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);
    }
}