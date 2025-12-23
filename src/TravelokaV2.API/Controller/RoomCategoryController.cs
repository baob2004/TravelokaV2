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

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] RoomCategoryCreateDto dto, CancellationToken ct)
        {
            var id = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [Authorize(Roles ="Admin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RoomCategoryUpdateDto dto, CancellationToken ct)
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

        // ===== Facilities =====
        [Authorize(Roles ="Admin")]
        [HttpPost("{roomCategoryId:guid}/facilities/{facilityId:guid}")]
        public async Task<IActionResult> LinkFacility(Guid roomCategoryId, Guid facilityId, CancellationToken ct)
        {
            await _service.LinkFacilityAsync(roomCategoryId, facilityId, ct);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{roomCategoryId:guid}/facilities/{facilityId:guid}")]
        public async Task<IActionResult> UnlinkFacility(Guid roomCategoryId, Guid facilityId, CancellationToken ct)
        {
            await _service.UnlinkFacilityAsync(roomCategoryId, facilityId, ct);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("{roomCategoryId:guid}/facilities/bulk")]
        public async Task<ActionResult<int>> LinkFacilities(Guid roomCategoryId, [FromBody] List<Guid> facilityIds, CancellationToken ct)
            => Ok(await _service.LinkFacilitiesAsync(roomCategoryId, facilityIds, ct));

        // ===== Images =====
        [Authorize(Roles ="Admin")]
        [HttpPost("{roomCategoryId:guid}/images/{imageId:guid}")]
        public async Task<IActionResult> LinkImage(Guid roomCategoryId, Guid imageId, CancellationToken ct)
        {
            await _service.LinkImageAsync(roomCategoryId, imageId, ct);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{roomCategoryId:guid}/images/{imageId:guid}")]
        public async Task<IActionResult> UnlinkImage(Guid roomCategoryId, Guid imageId, CancellationToken ct)
        {
            await _service.UnlinkImageAsync(roomCategoryId, imageId, ct);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("{roomCategoryId:guid}/images/bulk")]
        public async Task<ActionResult<int>> LinkImages(Guid roomCategoryId, [FromBody] List<Guid> imageIds, CancellationToken ct)
            => Ok(await _service.LinkImagesAsync(roomCategoryId, imageIds, ct));

        [Authorize(Roles ="Admin")]
        [HttpPost("bulk")]
        public async Task<ActionResult<IReadOnlyList<Guid>>> CreateMany([FromBody] List<RoomCategoryCreateDto> dtos, CancellationToken ct)
        {
            var ids = await _service.CreateManyAsync(dtos, ct);
            return Ok(ids);
        }
    }
}
