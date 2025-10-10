using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelokaV2.Application.DTOs.Auth;
using TravelokaV2.Application.Services.Identity;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService auth) : ControllerBase
{
    [HttpPost("register")]
    public Task<AuthResponse> Register([FromBody] RegisterRequest req, CancellationToken ct)
        => auth.RegisterAsync(req, ct);

    [HttpPost("login")]
    public Task<AuthResponse> Login([FromBody] LoginRequest req, CancellationToken ct)
        => auth.LoginAsync(req, ct);

    [HttpPost("refresh")]
    public Task<AuthResponse> Refresh([FromBody] RefreshRequest req, CancellationToken ct)
        => auth.RefreshAsync(req, ct);

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me(CancellationToken ct)
    {
        var cur = await auth.GetCurrentAsync(User, ct);
        return Ok(cur);
    }
}
