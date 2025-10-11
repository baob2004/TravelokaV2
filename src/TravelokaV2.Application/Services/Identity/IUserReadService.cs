namespace TravelokaV2.Application.Services.Identity
{
    public interface IUserReadService
    {
        Task<Dictionary<string, string>> GetUserNamesAsync(IEnumerable<string> userIds, CancellationToken ct);
    }
}