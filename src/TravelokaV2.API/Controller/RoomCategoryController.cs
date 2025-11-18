using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<Guid>> Create([FromBody] RoomCategoryCreateDto dto, CancellationToken ct)
        {
            var id = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RoomCategoryUpdateDto dto, CancellationToken ct)
        {
            await _service.UpdateAsync(id, dto, ct);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            await _service.DeleteAsync(id, ct);
            return NoContent();
        }

        // ===== Facilities =====
        [HttpPost("{roomCategoryId:guid}/facilities/{facilityId:guid}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> LinkFacility(Guid roomCategoryId, Guid facilityId, CancellationToken ct)
        {
            await _service.LinkFacilityAsync(roomCategoryId, facilityId, ct);
            return NoContent();
        }

        [HttpDelete("{roomCategoryId:guid}/facilities/{facilityId:guid}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UnlinkFacility(Guid roomCategoryId, Guid facilityId, CancellationToken ct)
        {
            await _service.UnlinkFacilityAsync(roomCategoryId, facilityId, ct);
            return NoContent();
        }

        [HttpPost("{roomCategoryId:guid}/facilities/bulk")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<int>> LinkFacilities(Guid roomCategoryId, [FromBody] List<Guid> facilityIds, CancellationToken ct)
            => Ok(await _service.LinkFacilitiesAsync(roomCategoryId, facilityIds, ct));

        // ===== Images =====
        [HttpPost("{roomCategoryId:guid}/images/{imageId:guid}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> LinkImage(Guid roomCategoryId, Guid imageId, CancellationToken ct)
        {
            await _service.LinkImageAsync(roomCategoryId, imageId, ct);
            return NoContent();
        }

        [HttpDelete("{roomCategoryId:guid}/images/{imageId:guid}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UnlinkImage(Guid roomCategoryId, Guid imageId, CancellationToken ct)
        {
            await _service.UnlinkImageAsync(roomCategoryId, imageId, ct);
            return NoContent();
        }

        [HttpPost("{roomCategoryId:guid}/images/bulk")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<int>> LinkImages(Guid roomCategoryId, [FromBody] List<Guid> imageIds, CancellationToken ct)
            => Ok(await _service.LinkImagesAsync(roomCategoryId, imageIds, ct));

        [HttpPost("bulk")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<IReadOnlyList<Guid>>> CreateMany([FromBody] List<RoomCategoryCreateDto> dtos, CancellationToken ct)
        {
            var ids = await _service.CreateManyAsync(dtos, ct);
            return Ok(ids);
        }
    }
}
