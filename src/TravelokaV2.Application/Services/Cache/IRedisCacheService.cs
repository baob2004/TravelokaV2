using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelokaV2.Application.Services.Cache
{
    public interface IRedisCacheService
    {
        T? GetData<T>(string key);
        void SetData<T>(string key, T data);
    }
}
