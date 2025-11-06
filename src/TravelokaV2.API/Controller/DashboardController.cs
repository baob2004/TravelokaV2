using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TravelokaV2.Application.DTOs.Dashboard;
using TravelokaV2.Application.Services; // IDashboardService
using TravelokaV2.Domain.Enums;

namespace TravelokaV2.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboard;

        public DashboardController(IDashboardService dashboard)
        {
            _dashboard = dashboard;
        }

        [HttpGet("income")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IReadOnlyList<AccomIncomeDto>), StatusCodes.Status200OK)]
        [OutputCache(Duration = 60, VaryByQueryKeys = new[] { "year", "from", "to", "granularity" })] // .NET 8
        public async Task<ActionResult<IReadOnlyList<AccomIncomeDto>>> GetIncome(
            [FromQuery] int? year,
            [FromQuery] DateOnly? from,
            [FromQuery] DateOnly? to,
            [FromQuery] TimeGranularity granularity = TimeGranularity.Day,
            CancellationToken ct = default)
        {
            var query = new IncomeQuery
            {
                Year = year,
                From = from,
                To = to,
                Granularity = granularity
            };

            var data = await _dashboard.GetIncomeAsync(query, ct);
            return Ok(data);
        }

        [HttpGet("accommodations/count")]
        public async Task<ActionResult<AccomNumberDto>> GetAccomNumber(CancellationToken ct)
            => Ok(await _dashboard.GetAccomNumberAsync(ct));

        [HttpGet("users/count")]
        public async Task<ActionResult<UserNumberDto>> GetUserNumber(CancellationToken ct)
            => Ok(await _dashboard.GetUserNumberAsync(ct));

        [HttpGet("reviews")]
        public async Task<ActionResult<IReadOnlyList<AccomReviewDto>>> GetReviews(
            [FromQuery] int? year,
            [FromQuery] DateOnly? from,
            [FromQuery] DateOnly? to,
            [FromQuery] TimeGranularity granularity = TimeGranularity.Day,
            CancellationToken ct = default)
        {
            var q = new ReviewQuery { Year = year, From = from, To = to, Granularity = granularity };
            var data = await _dashboard.GetReviewsAsync(q, ct);
            return Ok(data);
        }
    }
}
