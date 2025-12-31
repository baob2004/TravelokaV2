using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.Auth;
using TravelokaV2.Application.Services.Identity;
using TravelokaV2.Application.Services.Security;
using TravelokaV2.Infrastructure.Identity;
using TravelokaV2.Infrastructure.Persistence;

namespace TravelokaV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(UserManager<AppUser> userManager, IAuthService authService, IEmailSender emailSender, AppDbContext context) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IAuthService _auth = authService;
        private readonly IEmailSender _emailSender = emailSender;
        private readonly AppDbContext _context = context;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(req.Email);


            if (user == null || !user.EmailConfirmed)
                return StatusCode(400, new { Message = "Tài khoản không tồn tại hoặc chưa xác thực." });

            user.FullName = req.FullName;
            user.UserName = req.Email;

            var addPasswordResult = await _userManager.AddPasswordAsync(user, req.Password);
            if (!addPasswordResult.Succeeded)
                return StatusCode(400, addPasswordResult.Errors);

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                return StatusCode(500, new { Message = "Lỗi cập nhật thông tin người dùng.", updateResult.Errors });


            await _userManager.AddToRoleAsync(user, "User");
            await _userManager.RemoveAuthenticationTokenAsync(user, "Default", "EmailVerificationCode");


            return Ok(new { Message = "Đăng ký tài khoản thành công! Bạn có thể đăng nhập." });
        }

        [HttpPost("pre-register")]
        public async Task<IActionResult> PreRegister([FromBody] PreRegisterDto req, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(req.Email);

            if (existingUser != null && existingUser.EmailConfirmed)
            {
                return StatusCode(400, new { Message = "Email này đã được đăng ký và **đã được xác thực**." });
            }

            AppUser user;

            using var transaction = await _context.Database.BeginTransactionAsync(ct);

            try
            {
                var random = new Random();
                var verificationCode = random.Next(1000, 10000).ToString();

                if (existingUser == null)
                {
                    user = new AppUser
                    {
                        UserName = req.Email,
                        Email = req.Email,
                        EmailConfirmed = false,
                    };

                    var createUser = await _userManager.CreateAsync(user);

                    if (!createUser.Succeeded)
                    {
                        await transaction.RollbackAsync(ct);
                        return StatusCode(400, createUser.Errors);
                    }
                }
                else
                    user = existingUser;


                await _userManager.SetAuthenticationTokenAsync(user, "Default", "EmailVerificationCode", verificationCode);

                var emailBody = $@"
                <h3>Xác thực tài khoản</h3>
                <p>Mã xác thực của bạn là: <b>{verificationCode}</b></p>";

                await _emailSender.SendEmailAsync(user.Email!, "Mã xác thực", emailBody);
                await transaction.CommitAsync(ct);

                return Ok(new { Message = "Mã xác thực đã được gửi đến email của bạn.", user.Email });
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(ct);

                return StatusCode(500, new
                {
                    Message = "Lỗi hệ thống, không thể gửi mã xác thực. Vui lòng thử lại.",
                    ErrorMessage = e.Message
                });
            }
        }

        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail(VerifyEmailDto verifyDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(verifyDto.Email);
                if (user == null) return BadRequest("Email không tồn tại");

                var tokenInDb = await _userManager.GetAuthenticationTokenAsync(user, "Default", "EmailVerificationCode");

                if (tokenInDb != verifyDto.Code)
                    return BadRequest("Mã xác thực không chính xác");

                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                await _userManager.RemoveAuthenticationTokenAsync(user, "Default", "EmailVerificationCode");

                return Ok("Xác thực email thành công!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost("admin-register")]
        public Task<AuthResponse> AdminRegister([FromBody] AdminRegisterDto req, CancellationToken ct)
            => _auth.AdminRegisterAsync(req, ct);

        [HttpPost("login")]
        public Task<AuthResponse> Login([FromBody] LoginRequest req, CancellationToken ct)
            => _auth.LoginAsync(req, ct);

        [HttpPost("refresh")]
        public Task<AuthResponse> Refresh([FromBody] RefreshRequest req, CancellationToken ct)
            => _auth.RefreshAsync(req, ct);

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me(CancellationToken ct)
        {
            var cur = await _auth.GetCurrentAsync(User, ct);
            return Ok(cur);
        }

        [HttpGet("validate-email")]
        public async Task<IActionResult> EmailValidate([FromQuery] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return NotFound("Chưa xác nhận hoặc chưa tồn tại");
            else if (user != null && user.PasswordHash == null)
            {
                user.EmailConfirmed = false;
                await _userManager.UpdateAsync(user);
                return NotFound("Chưa xác nhận hoặc chưa tồn tại");
            }
            else return Ok("Đã được xác nhận");
        }
    }
}