using Microsoft.Extensions.DependencyInjection;
using TravelokaV2.Application.Mapping;

namespace TravelokaV2.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // ==== Add AutoMapper ====
            services.AddAutoMapper(typeof(TravelokaProfile).Assembly);

            return services;
        }
    }
}