using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.Accommodation;
using TravelokaV2.Application.DTOs.Common;
using TravelokaV2.Application.DTOs.GeneralInfo;
using TravelokaV2.Application.Services;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationService _service;
        public AccommodationController(IAccommodationService service) => _service = service;

        #region Accommodation
        [HttpGet]
        public async Task<ActionResult<PagedResult<AccomSummaryDto>>> GetPaged(
                    [FromQuery] PagedQuery pagedQuery,
                    [FromQuery] AccomSearchRequest request,
                    CancellationToken ct)
        {
            var result = await _service.GetPagedAsync(pagedQuery, request, ct);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AccomDetailDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _service.GetByIdAsync(id, ct);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] AccomCreateDto dto, CancellationToken ct)
        {
            var id = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AccomUpdateDto dto, CancellationToken ct)
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
        #endregion

        #region GeneralInfo
        [HttpGet("{accomId:guid}/general-info")]
        public async Task<ActionResult<GeneralInfoDto>> GetGeneralInfo(Guid accomId, CancellationToken ct)
        {
            var dto = await _service.GetGeneralInfoAsync(accomId, ct);
            return dto is null ? NotFound() : Ok(dto);
        }

        [HttpPut("{accomId:guid}/general-info")]
        public async Task<IActionResult> UpsertGeneralInfo(Guid accomId, [FromBody] GeneralInfoUpdateDto dto, CancellationToken ct)
        {
            await _service.UpsertGeneralInfoAsync(accomId, dto, ct);
            return NoContent();
        }

        [HttpDelete("{accomId:guid}/general-info")]
        public async Task<IActionResult> DeleteGeneralInfo(Guid accomId, CancellationToken ct)
        {
            await _service.DeleteGeneralInfoAsync(accomId, ct);
            return NoContent();
        }
        #endregion
    }
}
