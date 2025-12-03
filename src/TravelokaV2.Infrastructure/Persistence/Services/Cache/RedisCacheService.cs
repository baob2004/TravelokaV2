using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using TravelokaV2.Application.Services.Cache;

namespace TravelokaV2.Infrastructure.Persistence.Services.Cache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache? _cache;
        public RedisCacheService(IDistributedCache? cache)
        {
            _cache = cache;
        }

        public T? GetData<T>(string key)
        {
            var data = _cache?.GetString(key);
            if (data == null)
                return default;

            return JsonSerializer.Deserialize<T>(data);
        }

        public void SetData<T>(string key, T data)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
            };
            _cache?.SetString(key, JsonSerializer.Serialize(data), options);
        }
    }
}
