using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using TravelokaV2.API.Middlewares;
using TravelokaV2.Application;
using TravelokaV2.Application.Services.Cache;
using TravelokaV2.Application.Services.Security;
using TravelokaV2.Infrastructure;
using TravelokaV2.Infrastructure.Identity;
using TravelokaV2.Infrastructure.Persistence;
using TravelokaV2.Infrastructure.Persistence.Services.Cache;
using TravelokaV2.Infrastructure.Persistence.Services.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "Accoms_";
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelokaV2 API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme { Name = "Authorization", Type = SecuritySchemeType.Http, Scheme = "bearer", BearerFormat = "JWT", In = ParameterLocation.Header });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        { new OpenApiSecurityScheme { Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, Array.Empty<string>() }
    });

    c.MapType<TimeOnly>(() => new OpenApiSchema { Type = "string", Format = "time", Example = new OpenApiString("14:00") });
    c.MapType<TimeOnly?>(() => new OpenApiSchema { Type = "string", Format = "time", Nullable = true, Example = new OpenApiString("14:00") });
});

builder.Services.AddTransient<ErrorHandlingMiddleware>();


builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddIdentity<AppUser, IdentityRole>(option =>
{
    option.Password.RequireDigit = true;
    option.Password.RequireLowercase = true;
    option.Password.RequireUppercase = true;
    option.Password.RequireNonAlphanumeric = true;
    option.Password.RequiredLength = 8;
    option.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseCors("AllowAll");

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
