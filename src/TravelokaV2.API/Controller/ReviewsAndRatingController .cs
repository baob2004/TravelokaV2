using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.ReviewsAndRating;
using TravelokaV2.Application.Services;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsAndRatingController : ControllerBase
    {
        private readonly IReviewsService _service;
        public ReviewsAndRatingController(IReviewsService service) => _service = service;

        [HttpGet("Accommodations/{accomId:guid}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetByAccommodation(Guid accomId, CancellationToken ct)
            => Ok(await _service.GetByAccommodationAsync(accomId, ct));

        [Authorize(Roles ="User")]
        [HttpPost("Accommodations/{accomId:guid}")]
        public async Task<ActionResult<Guid>> Create(Guid accomId, [FromBody] ReviewCreateDto dto, CancellationToken ct)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                       ?? User.FindFirst("sub")?.Value;
            if (string.IsNullOrWhiteSpace(userId)) return Unauthorized();

            var userName = User.Identity?.Name
                       ?? User.FindFirst("name")?.Value
                       ?? User.FindFirst("preferred_username")?.Value;

            var id = await _service.CreateAsync(accomId, dto, userId, userName, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReviewDto>> GetById(Guid id, CancellationToken ct)
            => Ok(await _service.GetByIdAsync(id, ct));

        [Authorize(Roles ="User")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ReviewUpdateDto dto, CancellationToken ct)
        {
            await _service.UpdateAsync(id, dto, ct);
            return NoContent();
        }

        [Authorize(Roles ="User")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            await _service.DeleteAsync(id, ct);
            return NoContent();
        }
    }
}
