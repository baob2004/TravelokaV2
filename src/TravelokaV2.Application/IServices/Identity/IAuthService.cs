using System.Security.Claims;
using TravelokaV2.Application.DTOs.Auth;

namespace TravelokaV2.Application.Services.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest req, CancellationToken ct = default);
        Task<AuthResponse> AdminRegisterAsync(AdminRegisterDto req, CancellationToken ct = default);
        Task<AuthResponse> LoginAsync(LoginRequest req, CancellationToken ct = default);
        Task<(string UserId, string UserName, string Email, IEnumerable<string> Roles)?> GetCurrentAsync(ClaimsPrincipal principal, CancellationToken ct = default);
        Task<AuthResponse> RefreshAsync(RefreshRequest req, CancellationToken ct = default);
        Task<bool> IsExist(string email);
    }
}