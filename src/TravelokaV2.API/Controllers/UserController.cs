using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.User;
using TravelokaV2.Infrastructure.Identity;

namespace TravelokaV2.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserManager<AppUser> userManager) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var _ = await _userManager.FindByIdAsync(id);
            if (_ == null)
                return NotFound("Đã có lỗi xảy ra!");

            UserPersonalInfoDto user = new()
            {
                FullName = _.FullName,
                BirthDate = _.BirthDate,
                Sex = _.Sex,
                Email = _.Email!
            };

            return Ok(user);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UserUpdateDto dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound("User không tồn tại");

            user.FullName = dto.FullName ?? string.Empty;
            user.BirthDate = dto.BirthDate;
            user.Sex = dto.Sex;

            var rs = await _userManager.UpdateAsync(user);
            if (!rs.Succeeded) return BadRequest(rs.Errors);

            return Ok(new { Message = "Cập nhật thành công" });
        }

    }
}
