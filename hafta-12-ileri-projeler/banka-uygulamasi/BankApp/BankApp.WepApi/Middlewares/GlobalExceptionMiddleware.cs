using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankApp.WepApi.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
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
              _logger.LogError(ex, "Bir Hata oluştu");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    success = false,
                    message = _env.IsDevelopment() ? ex.Message : "Bir hata oluştu lütfen daha sonra tekrar deneyin",
                    details = _env.IsDevelopment() ? ex.ToString() : null
                };

                var jsonResponse = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }// end of class GlobalExceptionMiddleware
}
