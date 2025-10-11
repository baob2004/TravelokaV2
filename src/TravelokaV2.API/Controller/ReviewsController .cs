// API/Controllers/ReviewsController.cs
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

        [HttpPost("Accommodations/{accomId:guid}")]
        public async Task<ActionResult<Guid>> Create(Guid accomId, [FromBody] ReviewCreateDto dto, CancellationToken ct)
        {
            var id = await _service.CreateAsync(accomId, dto, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReviewDto>> GetById(Guid id, CancellationToken ct)
            => Ok(await _service.GetByIdAsync(id, ct));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ReviewUpdateDto dto, CancellationToken ct)
        {
            await _service.UpdateAsync(id, dto, ct);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            await _service.DeleteAsync(id, ct);
            return NoContent();
        }
    }
}
