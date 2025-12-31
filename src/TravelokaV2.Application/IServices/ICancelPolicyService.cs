using TravelokaV2.Application.DTOs.CancelPolicy;

namespace TravelokaV2.Application.Services
{
    public interface ICancelPolicyService
    {
        Task<IEnumerable<CancelPolicyDto>> GetAllAsync(CancellationToken ct);
        Task<CancelPolicyDto> GetByIdAsync(Guid id, CancellationToken ct);
        Task<Guid> CreateAsync(CancelPolicyCreateDto dto, CancellationToken ct);
        Task UpdateAsync(Guid id, CancelPolicyUpdateDto dto, CancellationToken ct);
        Task DeleteAsync(Guid id, CancellationToken ct);

    }
}