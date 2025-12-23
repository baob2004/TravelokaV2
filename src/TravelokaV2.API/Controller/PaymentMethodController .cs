using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.PaymentMethod;
using TravelokaV2.Application.Services;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _service;
        public PaymentMethodController(IPaymentMethodService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethodDto>>> GetAll(CancellationToken ct)
            => Ok(await _service.GetAllAsync(ct));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PaymentMethodDto>> GetById(Guid id, CancellationToken ct)
            => Ok(await _service.GetByIdAsync(id, ct));

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] PaymentMethodCreateDto dto, CancellationToken ct)
        {
            var id = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PaymentMethodUpdateDto dto, CancellationToken ct)
        {
            await _service.UpdateAsync(id, dto, ct);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            await _service.DeleteAsync(id, ct);
            return NoContent();
        }
    }
}
