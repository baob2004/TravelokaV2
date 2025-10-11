using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelokaV2.Application.Services.Identity;
using TravelokaV2.Infrastructure.Identity;

public class UserReadService : IUserReadService
{
    private readonly UserManager<AppUser> _userManager;
    public UserReadService(UserManager<AppUser> userManager) => _userManager = userManager;

    public async Task<Dictionary<string, string>> GetUserNamesAsync(IEnumerable<string> userIds, CancellationToken ct)
    {
        var ids = userIds.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        return await _userManager.Users
            .Where(u => ids.Contains(u.Id))
            .Select(u => new { u.Id, u.UserName })
            .ToDictionaryAsync(x => x.Id, x => x.UserName ?? string.Empty, ct);
    }
}
