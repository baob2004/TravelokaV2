
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.DTOs.Auth;
using TravelokaV2.Application.Services.Identity;
using TravelokaV2.Application.Services.Security;
using TravelokaV2.Domain.Entities;
using TravelokaV2.Infrastructure.Identity;

namespace TravelokaV2.Infrastructure.Persistence.Services.Identity
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailSender _emailSender;

        public AuthService(
            AppDbContext db,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            IEmailSender emailSender)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailSender = emailSender;
        }

        private static string NewRefreshToken()
            => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        private static DateTime RefreshExpiry(int days = 30)
            => DateTime.UtcNow.AddDays(days);

        public async Task<AuthResponse> AdminRegisterAsync(AdminRegisterDto req, CancellationToken ct = default)
        {
            var user = new AppUser
            {
                UserName = req.Username,
                Email = $"{req.Username}@gmail.com",
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                EmailConfirmed = true ,
            };

            var result = await _userManager.CreateAsync(user, req.Password);
            if (!result.Succeeded)
            {
                var error = string.Join("; ", result.Errors.Select(e => $"{e.Code}:{e.Description}"));
                throw new InvalidOperationException(error);
            }

            const string defaultRole = "Admin";
            await _userManager.AddToRoleAsync(user, defaultRole);

            await _db.SaveChangesAsync(ct);

            return new AuthResponse
            {
                UserId = user.Id,
                UserName = user.UserName ?? "",
                Email = user.Email ?? ""
            };
        }

        public async Task<(string UserId, string UserName, string Email, IEnumerable<string> Roles)?> GetCurrentAsync(ClaimsPrincipal principal, CancellationToken ct = default)
        {
            var id = _userManager.GetUserId(principal);
            if (string.IsNullOrEmpty(id)) return null;

            var user = await _userManager.FindByIdAsync(id);
            if (user is null) return null;

            var roles = await _userManager.GetRolesAsync(user);
            return (user.Id, user.UserName ?? "", user.Email ?? "", roles);
        }

        public async Task<bool> IsExist(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) 
                return false;
            return true;
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest req, CancellationToken ct = default)
        {
            var user = await _userManager.FindByNameAsync(req.UserNameOrEmail)
            ?? await _userManager.FindByEmailAsync(req.UserNameOrEmail);

            if (user is null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var pass = await _signInManager.CheckPasswordSignInAsync(user, req.Password, lockoutOnFailure: true);
            if (!pass.Succeeded)
                throw new UnauthorizedAccessException("Invalid credentials");

            var roles = await _userManager.GetRolesAsync(user);
            var access = _tokenService.CreateAccessToken(user.Id, user.UserName, user.Email, roles);

            var raw = NewRefreshToken();
            _db.RefreshTokens.Add(new RefreshToken
            {
                UserId = user.Id,
                Token = raw,
                ExpiresAtUtc = RefreshExpiry(30)
            });
            await _db.SaveChangesAsync(ct);

            return new AuthResponse
            {
                AccessToken = access,
                RefreshToken = raw,
                UserId = user.Id,
                UserName = user.UserName ?? "",
                Email = user.Email ?? ""
            };
        }

        public async Task<AuthResponse> RefreshAsync(RefreshRequest req, CancellationToken ct = default)
        {
            var token = await _db.RefreshTokens
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Token == req.RefreshToken, ct);

            if (token is null || token.ExpiresAtUtc <= DateTime.UtcNow)
                throw new UnauthorizedAccessException("Invalid or expired refresh token");

            var user = await _userManager.FindByIdAsync(token.UserId)
                       ?? throw new UnauthorizedAccessException("User not found");

            var roles = await _userManager.GetRolesAsync(user);
            var access = _tokenService.CreateAccessToken(user.Id, user.UserName, user.Email, roles);

            return new AuthResponse
            {
                AccessToken = access,
                RefreshToken = req.RefreshToken,
                UserId = user.Id,
                UserName = user.UserName ?? "",
                Email = user.Email ?? ""
            };
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest req, CancellationToken ct = default)
        {
            var user = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = req.Email,
                Email = req.Email,
                FullName = req.FullName,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, req.Password);
            if (!result.Succeeded)
            {
                var error = string.Join("; ", result.Errors.Select(e => $"{e.Code}:{e.Description}"));
                throw new InvalidOperationException(error);
            }

            const string defaultRole = "User";
            await _userManager.AddToRoleAsync(user, defaultRole);

            var roles = await _userManager.GetRolesAsync(user);
            var access = _tokenService.CreateAccessToken(user.Id, user.UserName, user.Email, roles);

            var raw = NewRefreshToken();
            _db.RefreshTokens.Add(new RefreshToken
            {
                UserId = user.Id,
                Token = raw,
                ExpiresAtUtc = RefreshExpiry(30)
            });
            await _db.SaveChangesAsync(ct);

            return new AuthResponse
            {
                AccessToken = access,
                RefreshToken = raw,
                UserId = user.Id,
                UserName = user.UserName ?? "",
                Email = user.Email ?? ""
            };
        }
    }
}