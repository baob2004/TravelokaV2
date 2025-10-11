using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.RoomCategory;
using TravelokaV2.Application.Services;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomCategoryController : ControllerBase
    {
        private readonly IRoomCategoryService _service;
        public RoomCategoryController(IRoomCategoryService service) => _service = service;

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RoomCategoryDto>> GetById(Guid id, CancellationToken ct)
            => Ok(await _service.GetByIdAsync(id, ct));

        [HttpGet("Accommodations/{accomId:guid}")]
        public async Task<ActionResult<IEnumerable<RoomCategoryDto>>> GetByAccommodation(Guid accomId, CancellationToken ct)
            => Ok(await _service.GetByAccommodationAsync(accomId, ct));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] RoomCategoryCreateDto dto, CancellationToken ct)
        {
            var id = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RoomCategoryUpdateDto dto, CancellationToken ct)
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
