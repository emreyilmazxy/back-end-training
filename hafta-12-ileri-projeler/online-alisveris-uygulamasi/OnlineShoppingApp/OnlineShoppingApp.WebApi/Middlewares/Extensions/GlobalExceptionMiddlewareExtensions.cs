using OnlineShoppingApp.WebApi.Middlewares;

namespace OnlineShoppingApp.WebApi.Middlewares.Extensions
{
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    } // GlobalExceptionMiddlewareExtensions class done
}
