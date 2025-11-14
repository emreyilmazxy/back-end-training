using OnlineShoppingApp.WebApi.Middlewares;

namespace OnlineShoppingApp.WebApi.Middlewares.Extensions
{
    public static class RequestLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
