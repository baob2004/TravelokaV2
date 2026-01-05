using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using TravelokaV2.API.Middlewares;
using TravelokaV2.Application;
using TravelokaV2.Infrastructure;
using VNPAY.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

#region Redis Service Config
builder.Services.AddStackExchangeRedisCache(options =>
{
    var config = new ConfigurationOptions
    {
        EndPoints = { builder.Configuration["Redis:EndPoint"]! },
        Password = builder.Configuration["Redis:Password"],
    };

    options.ConfigurationOptions = config;
    options.InstanceName = "Accoms_";
});
#endregion

#region Swagger Service Config
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });
});
#endregion

#region CORS config
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
#endregion

#region VNPay Service Config
var vnpayConfig = builder.Configuration.GetSection("VNPAY");

builder.Services.AddVnpayClient(config =>
{
    config.TmnCode = vnpayConfig["TmnCode"]!;
    config.HashSecret = vnpayConfig["HashSecret"]!;
    config.CallbackUrl = vnpayConfig["CallbackUrl"]!;
    // config.BaseUrl = vnpayConfig["BaseUrl"]!; // Tùy chọn. Nếu không thiết lập, giá trị mặc định là URL thanh toán môi trường TEST
    // config.Version = vnpayConfig["Version"]!; // Tùy chọn. Nếu không thiết lập, giá trị mặc định là "2.1.0"
    // config.OrderType = vnpayConfig["OrderType"]!; // Tùy chọn. Nếu không thiết lập, giá trị mặc định là "other"
});
#endregion

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddTransient<ErrorHandlingMiddleware>();

builder.Services.AddApplication();


var app = builder.Build();


app.MapDefaultEndpoints();

app.UseCors("AllowAll");

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations();

//app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
