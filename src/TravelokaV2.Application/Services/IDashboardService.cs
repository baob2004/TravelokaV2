using TravelokaV2.Application.DTOs.Dashboard;

namespace TravelokaV2.Application.Services
{
    public interface IDashboardService
    {
        Task<IReadOnlyList<AccomIncomeDto>> GetIncomeAsync(IncomeQuery q, CancellationToken ct = default);
        Task<AccomNumberDto> GetAccomNumberAsync(CancellationToken ct = default);
        Task<UserNumberDto> GetUserNumberAsync(CancellationToken ct = default);
        Task<IReadOnlyList<AccomReviewDto>> GetReviewsAsync(ReviewQuery q, CancellationToken ct = default);
    }
}