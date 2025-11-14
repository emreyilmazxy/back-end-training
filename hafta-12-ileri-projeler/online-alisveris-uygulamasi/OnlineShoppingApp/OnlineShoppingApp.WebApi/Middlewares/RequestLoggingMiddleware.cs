using OnlineShoppingApp.WebApi.Jwt;
using System.Security.Claims;

namespace OnlineShoppingApp.WebApi.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var now = DateTime.Now;

            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier)
                       ?? context.User.FindFirstValue(JwtClaimNames.Id)
                       ?? context.User.Identity?.Name
                       ?? "Anonymous";

            var method = context.Request.Method;
            var url = $"{context.Request.Path}{context.Request.QueryString}";

            _logger.LogInformation("Request: {method} {Url} | Time: {Time} | User: {User}",
              method, url, now, userId);

            await _next(context);
        }
    }
}
