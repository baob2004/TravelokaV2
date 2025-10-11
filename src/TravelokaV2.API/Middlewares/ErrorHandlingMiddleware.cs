using System.Net;
using System.Text.Json;

namespace TravelokaV2.API.Middlewares;

public sealed class ErrorHandlingMiddleware : IMiddleware
{
    private readonly IHostEnvironment _env;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(IHostEnvironment env, ILogger<ErrorHandlingMiddleware> logger)
    {
        _env = env;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var traceId = context.TraceIdentifier;

        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception. TraceId={TraceId}", traceId);

            if (context.Response.HasStarted) throw;

            var (status, title) = Map(ex);

            var problem = new
            {
                type = $"about:blank",
                title,
                status = (int)status,
                message = GetUserMessage(ex),
                traceId,
                path = context.Request.Path.Value,
                method = context.Request.Method,
                // chỉ show stack ở Dev
                detail = _env.IsDevelopment() ? ex.ToString() : null
            };

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = (int)status;

            var json = JsonSerializer.Serialize(problem, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = _env.IsDevelopment()
            });

            await context.Response.WriteAsync(json);
        }
    }

    private static (HttpStatusCode, string) Map(Exception ex) => ex switch
    {
        KeyNotFoundException => (HttpStatusCode.NotFound, "Resource Not Found"),
        UnauthorizedAccessException => (HttpStatusCode.Unauthorized, "Unauthorized"),
        ArgumentException => (HttpStatusCode.BadRequest, "Invalid Argument"),
        InvalidOperationException => (HttpStatusCode.BadRequest, "Invalid Operation"),
        _ => (HttpStatusCode.InternalServerError, "Internal Server Error")
    };

    private static string GetUserMessage(Exception ex) => ex switch
    {
        KeyNotFoundException knf => knf.Message,
        ArgumentException aex => aex.Message,
        InvalidOperationException ioe => ioe.Message,
        _ => "Something went wrong. Please try again later."
    };
}
