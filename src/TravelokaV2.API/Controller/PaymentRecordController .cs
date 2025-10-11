// API/Controllers/PaymentRecordsController.cs
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.PaymentRecord;
using TravelokaV2.Application.Services;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentRecordsController : ControllerBase
    {
        private readonly IPaymentRecordService _service;
        public PaymentRecordsController(IPaymentRecordService service) => _service = service;

        [HttpPost]
        [Authorize]
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

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PaymentRecordUpdateDto dto, CancellationToken ct)
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
