namespace TravelokaV2.Application.Services.Security
{
    public interface ITokenService
    {
        string CreateAccessToken(string userId, string? userName, string? email, IEnumerable<string> roles);
    }
}