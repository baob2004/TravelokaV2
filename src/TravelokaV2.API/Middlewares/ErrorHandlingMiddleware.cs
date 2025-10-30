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
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);

            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new
                {
                    success = false,
                    error = ex.Message,
                    traceId = context.TraceIdentifier
                });
                await context.Response.WriteAsync(result);
            }
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
