using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace OnlineShoppingApp.WebApi.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env; // ortam bilgisi

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Bir hata oluştu.");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new
            {
                Success = false,
                Message = _env.IsDevelopment()
                    ? ex.Message
                    : "Bir hata oluştu, lütfen daha sonra tekrar deneyin.",
                Detail = _env.IsDevelopment() ? ex.InnerException?.Message : null
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
            }
        }
    } // GlobalExceptionMiddleware class done
}
