using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.CancelPolicy;
using TravelokaV2.Application.Services;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CancelPolicyController : ControllerBase
    {
        private readonly ICancelPolicyService _service;
        public CancelPolicyController(ICancelPolicyService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancelPolicyDto>>> GetAll(CancellationToken ct)
            => Ok(await _service.GetAllAsync(ct));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CancelPolicyDto>> GetById(Guid id, CancellationToken ct)
            => Ok(await _service.GetByIdAsync(id, ct));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CancelPolicyCreateDto dto, CancellationToken ct)
        {
            var id = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CancelPolicyUpdateDto dto, CancellationToken ct)
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
