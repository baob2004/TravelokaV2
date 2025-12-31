using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.Accommodation;
using TravelokaV2.Application.DTOs.Assignments.Accommodation;
using TravelokaV2.Application.DTOs.Common;
using TravelokaV2.Application.DTOs.GeneralInfo;
using TravelokaV2.Application.DTOs.Policy;
using TravelokaV2.Application.Services;
using TravelokaV2.Application.Services.Cache;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationService _service;
        private readonly IRedisCacheService _cache;
        public AccommodationController(IAccommodationService service, IRedisCacheService cache)
        {
            _service = service;
            _cache = cache;
        }

        #region Accommodation
        [HttpGet]
        public async Task<ActionResult<PagedResult<AccomSummaryDto>>> GetPaged(
                    [FromQuery] PagedQuery pagedQuery,
                    [FromQuery] AccomSearchRequest request,
                    CancellationToken ct)
        {
            string cacheKey = $"accom_{pagedQuery.Page}_{pagedQuery.PageSize}_{request.GetHashCode()}";

            var cached = _cache.GetData<PagedResult<AccomSummaryDto>>(cacheKey);
            if (cached is not null)
            {
                return Ok(cached);
            }

            var result = await _service.GetPagedAsync(pagedQuery, request, ct);

            _cache.SetData(cacheKey, result);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AccomDetailDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _service.GetByIdAsync(id, ct);
            return Ok(dto);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] AccomCreateDto dto, CancellationToken ct)
        {
            var id = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("bulk")]
        public async Task<ActionResult<IReadOnlyList<Guid>>> CreateMany([FromBody] List<AccomCreateDto> dtos, CancellationToken ct)
        {
            var ids = await _service.CreateManyAsync(dtos, ct);
            return Ok(ids);
        }

        [Authorize(Roles ="Admin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AccomUpdateDto dto, CancellationToken ct)
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
        #endregion

        #region GeneralInfo
        [HttpGet("{accomId:guid}/general-info")]
        public async Task<ActionResult<GeneralInfoDto>> GetGeneralInfo(Guid accomId, CancellationToken ct)
        {
            var dto = await _service.GetGeneralInfoAsync(accomId, ct);
            return dto is null ? NotFound() : Ok(dto);
        }

        [Authorize(Roles ="Admin")]
        [HttpPut("{accomId:guid}/general-info")]
        public async Task<IActionResult> UpsertGeneralInfo(Guid accomId, [FromBody] GeneralInfoUpdateDto dto, CancellationToken ct)
        {
            await _service.UpsertGeneralInfoAsync(accomId, dto, ct);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{accomId:guid}/general-info")]
        public async Task<IActionResult> DeleteGeneralInfo(Guid accomId, CancellationToken ct)
        {
            await _service.DeleteGeneralInfoAsync(accomId, ct);
            return NoContent();
        }
        #endregion

        #region Policy
        [HttpGet("{accomId:guid}/policy")]
        public async Task<ActionResult<PolicyDto>> GetPolicy(Guid accomId, CancellationToken ct)
        {
            var dto = await _service.GetPolicyAsync(accomId, ct);
            return dto is null ? NotFound() : Ok(dto);
        }

        [Authorize(Roles ="Admin")]
        [HttpPut("{accomId:guid}/policy")]
        public async Task<IActionResult> UpsertPolicy(Guid accomId, [FromBody] PolicyUpdateDto dto, CancellationToken ct)
        {
            await _service.UpsertPolicyAsync(accomId, dto, ct);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{accomId:guid}/policy")]
        public async Task<IActionResult> DeletePolicy(Guid accomId, CancellationToken ct)
        {
            await _service.DeletePolicyAsync(accomId, ct);
            return NoContent();
        }
        #endregion

        #region Assign Image
        [HttpPost("{accomId}/images")]
        public async Task<IActionResult> LinkImage(Guid accomId, [FromBody] Guid imageId, CancellationToken ct)
        {
            await _service.LinkImageAsync(accomId, imageId, ct);
            return Ok("Link image successfully!");
        }

        [HttpDelete("{accomId:guid}/images/{imageId:guid}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UnlinkImage(Guid accomId, Guid imageId, CancellationToken ct)
        {
            await _service.UnlinkImageAsync(accomId, imageId, ct);
            return NoContent();
        }

        [HttpPost("{accomId:guid}/images/bulk")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<int>> LinkImages(Guid accomId, [FromBody] List<Guid> imageIds, CancellationToken ct)
            => Ok(await _service.LinkImagesAsync(accomId, imageIds, ct));


        #endregion

        #region Assign Facility
        [Authorize(Roles = "Admin")]
        [HttpPost("{accomId:guid}/facilites")]
        public async Task<IActionResult> LinkFacility(Guid accomId,[FromBody] Guid faciltyId, CancellationToken ct)
        {
            await _service.LinkFacilityAsync(accomId, faciltyId, ct);
            return Ok("Link facility successfully!");
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{accomId:guid}/facilities/{facilityId:guid}")]
        public async Task<IActionResult> UnlinkFacility(Guid accomId, Guid facilityId, CancellationToken ct)
        {
            await _service.UnlinkFacilityAsync(accomId, facilityId, ct);
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("{accomId:guid}/facilities/bulk")]
        public async Task<ActionResult<int>> LinkFacilities(Guid accomId, [FromBody] List<Guid> facilityIds, CancellationToken ct)
            => Ok(await _service.LinkFacilitiesAsync(accomId, facilityIds, ct));
        #endregion

    }
}
