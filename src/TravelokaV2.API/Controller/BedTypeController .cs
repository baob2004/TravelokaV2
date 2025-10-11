using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.BedType;
using TravelokaV2.Application.Services;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BedTypesController : ControllerBase
    {
        private readonly IBedTypeService _service;
        public BedTypesController(IBedTypeService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BedTypeDto>>> GetAll(CancellationToken ct)
            => Ok(await _service.GetAllAsync(ct));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BedTypeDto>> GetById(Guid id, CancellationToken ct)
            => Ok(await _service.GetByIdAsync(id, ct));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] BedTypeCreateDto dto, CancellationToken ct)
        {
            var id = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BedTypeUpdateDto dto, CancellationToken ct)
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
