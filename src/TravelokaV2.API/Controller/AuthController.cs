using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.Auth;
using TravelokaV2.Application.Services.Identity;
using TravelokaV2.Application.Services.Security;
using TravelokaV2.Infrastructure.Identity;
using TravelokaV2.Infrastructure.Persistence;

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
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // 1. Tìm User Tạm thời bằng Email
        var user = await _userManager.FindByEmailAsync(req.Email);


        if (user == null || !user.EmailConfirmed) // Code là mã OTP người dùng gửi lên
        {
            return StatusCode(400, new { Message = "Tài khoản không tồn tại hoặc chưa xác thực." });
        }

        // Nếu Code đúng, chúng ta không cần dùng Transaction nữa, 
        // chỉ cần Update thông tin và Password.

        // 3. Cập nhật thông tin User và đặt Password
        user.FullName = req.FullName;
        user.UserName = req.Email;

        // _userManager.AddPasswordAsync sẽ tạo Hash cho mật khẩu và lưu vào DB
        var addPasswordResult = await _userManager.AddPasswordAsync(user, req.Password);
        if (!addPasswordResult.Succeeded)
        {
            // Nếu thêm password thất bại (ví dụ: password quá yếu)
            return StatusCode(400, addPasswordResult.Errors);
        }

        // Cập nhật thông tin FullName và EmailConfirmed
        var updateResult = await _userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
        {
            return StatusCode(500, new { Message = "Lỗi cập nhật thông tin người dùng.", Errors = updateResult.Errors });
        }

        // Thêm Role
        await _userManager.AddToRoleAsync(user, "User");

        // Xóa mã xác thực đã dùng để tránh tái sử dụng
        await _userManager.RemoveAuthenticationTokenAsync(user, "Default", "EmailVerificationCode");


        return Ok(new { Message = "Đăng ký tài khoản thành công! Bạn có thể đăng nhập." });
    }

    [HttpPost("pre-register")]
    public async Task<IActionResult> PreRegister([FromBody] PreRegisterDto req, CancellationToken ct)
    {
        // Kiểm tra tính hợp lệ cơ bản của ModelState (ví dụ: email có đúng định dạng)
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // 1. Kiểm tra xem User đã tồn tại chưa
        var existingUser = await _userManager.FindByEmailAsync(req.Email);

        // **Điều kiện mới:** Nếu user đã tồn tại VÀ email ĐÃ xác thực, thông báo lỗi.
        // (Nếu user tồn tại nhưng email CHƯA xác thực, ta sẽ cho phép gửi lại mã/cập nhật)
        if (existingUser != null && existingUser.EmailConfirmed)
        {
            return StatusCode(400, new { Message = "Email này đã được đăng ký và **đã được xác thực**." });
        }

        // Khởi tạo biến user cần thao tác (sẽ là existingUser hoặc user mới)
        AppUser user;

        // Bắt đầu Transaction
        using var transaction = await _context.Database.BeginTransactionAsync(ct);

        try
        {
            var random = new Random();
            // 2. Tạo mã OTP (One-Time Password)
            var verificationCode = random.Next(1000, 10000).ToString();

            // 3. Tạo User Tạm thời HOẶC Cập nhật User Tồn tại
            if (existingUser == null)
            {
                // User CHƯA tồn tại -> Tạo user mới tạm thời
                user = new AppUser
                {
                    UserName = req.Email, // UserName = Email
                    Email = req.Email,
                    EmailConfirmed = false, // Rất quan trọng: Đánh dấu là chưa xác thực
                };

                // Lệnh này ghi vào DB, nhưng chưa Commit
                // Chúng ta không dùng CreateAsync(user, password) vì chưa có password
                var createUser = await _userManager.CreateAsync(user);

                if (!createUser.Succeeded)
                {
                    // Lỗi DB khi tạo user
                    await transaction.RollbackAsync();
                    return StatusCode(400, createUser.Errors);
                }
            }
            else
            {
                // User ĐÃ tồn tại nhưng CHƯA xác thực -> Cập nhật user hiện tại
                user = existingUser;
            }

            // 4. Lưu mã OTP vào DB.
            // SetAuthenticationTokenAsync sẽ tự động lưu (update) vào DB (cho cả user mới và user cũ)
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "EmailVerificationCode", verificationCode);

            // 5. Gửi Email (Rủi ro cao nhất nằm ở đây)
            var emailBody = $@"
<h3>Xác thực tài khoản</h3>
<p>Mã xác thực của bạn là: <b>{verificationCode}</b></p>";

            // Nếu dòng này lỗi -> Nhảy xuống catch -> Rollback
            await _emailSender.SendEmailAsync(user.Email!, "Mã xác thực", emailBody);

            // 6. Nếu code chạy đến đây nghĩa là DB đã update và Email đã gửi OK -> CHỐT SỔ
            await transaction.CommitAsync();

            return Ok(new { Message = "Mã xác thực đã được gửi đến email của bạn.", Email = user.Email });
        }
        catch (Exception e)
        {
            // 7. Nếu có lỗi xảy ra (đặc biệt là lỗi gửi mail) -> HOÀN TÁC
            await transaction.RollbackAsync();

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

            // Lấy mã OTP đã lưu trong database ra
            var tokenInDb = await _userManager.GetAuthenticationTokenAsync(user, "Default", "EmailVerificationCode");

            // So sánh mã người dùng nhập và mã trong DB
            if (tokenInDb != verifyDto.Code)
            {
                return BadRequest("Mã xác thực không chính xác");
            }

            // Nếu đúng, kích hoạt EmailConfirmed
            user.EmailConfirmed = true;

            await _userManager.UpdateAsync(user);

            // Xóa mã OTP sau khi dùng xong (để không dùng lại được nữa)
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
    public async Task<IActionResult> EmailValidate([FromQuery]string email) 
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
