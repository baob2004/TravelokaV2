using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.Room;
using TravelokaV2.Application.Services;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;
        public RoomController(IRoomService service) => _service = service;

        // Detail
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RoomDetailDto>> GetById(Guid id, CancellationToken ct)
            => Ok(await _service.GetByIdAsync(id, ct));

        // List theo RoomCategory (summary)
        [HttpGet("Categories/{categoryId:guid}")]
        public async Task<ActionResult<IEnumerable<RoomSummaryDto>>> GetByCategory(Guid categoryId, CancellationToken ct)
            => Ok(await _service.GetByCategoryAsync(categoryId, ct));

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] RoomCreateDto dto, CancellationToken ct)
        {
            var id = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [Authorize(Roles ="Admin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RoomUpdateDto dto, CancellationToken ct)
        {
            await _service.UpdateAsync(id, dto, ct);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            await _service.DeleteAsync(id, ct);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("bulk")]
        public async Task<ActionResult<IReadOnlyList<Guid>>> CreateMany([FromBody] List<RoomCreateDto> dtos, CancellationToken ct)
        {
            var ids = await _service.CreateManyAsync(dtos, ct);
            return Ok(ids);
        }
    }
}
