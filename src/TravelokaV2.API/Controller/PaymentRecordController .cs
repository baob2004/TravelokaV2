using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.PaymentRecord;
using TravelokaV2.Application.Services;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentRecordController : ControllerBase
    {
        private readonly IPaymentRecordService _service;
        public PaymentRecordController(IPaymentRecordService service) => _service = service;

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] PaymentRecordCreateDto dto, CancellationToken ct)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                       ?? User.FindFirst("sub")?.Value;

            if (string.IsNullOrWhiteSpace(userId))
                return Unauthorized();

            var id = await _service.CreateAsync(dto, userId, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PaymentRecordDto>> GetById(Guid id, CancellationToken ct)
            => Ok(await _service.GetByIdAsync(id, ct));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentRecordDto>>> GetAll(CancellationToken ct)
            => Ok(await _service.GetAllAsync(ct));

        [Authorize(Roles ="Admin")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PaymentRecordUpdateDto dto, CancellationToken ct)
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

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<PaymentRecordDto>> GetByUserId(CancellationToken ct)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                       ?? User.FindFirst("sub")?.Value;
            if (string.IsNullOrWhiteSpace(userId)) return Unauthorized();

            return Ok(await _service.GetByUserIdAsync(userId, ct));
        }
    }
}
