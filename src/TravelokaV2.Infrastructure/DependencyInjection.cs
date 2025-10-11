using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TravelBooking.Infrastructure.Persistence.Repositories;
using TravelokaV2.Application.Interfaces;
using TravelokaV2.Application.Services;
using TravelokaV2.Application.Services.Identity;
using TravelokaV2.Application.Services.Security;
using TravelokaV2.Infrastructure.Identity;
using TravelokaV2.Infrastructure.Persistence;
using TravelokaV2.Infrastructure.Persistence.Repositories;
using TravelokaV2.Infrastructure.Persistence.Services;
using TravelokaV2.Infrastructure.Persistence.Services.Identity;
using TravelokaV2.Infrastructure.Persistence.Services.Security;

namespace TravelokaV2.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
        {
            // ==== DbContext ====
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(cfg.GetConnectionString("DefaultConnection"))
            );

            // ==== JWT Options ====
            services.Configure<JwtOptions>(cfg.GetSection("Jwt"));

            // ===== Identity Core =====
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireDigit = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredLength = 8;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

            // ===== JWT Auth =====
            var issuer = cfg["Jwt:Issuer"];
            var audience = cfg["Jwt:Audience"];
            var key = cfg["Jwt:Key"]!;
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = cfg["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = cfg["JWT:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["JWT:Key"]!)),
                    ValidateIssuerSigningKey = true,
                    RoleClaimType = ClaimTypes.Role
                };
            });

            // ==== DI Repository and UnitOfWork ====
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // ==== Service ====
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IAccommodationService, AccommodationService>();
            services.AddScoped<IAccomTypeService, AccomTypeService>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IImageService, ImageService>();
            return services;
        }
    }
}