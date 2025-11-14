using OnlineShoppingApp.WebApi.Middlewares;

namespace OnlineShoppingApp.WebApi.Middlewares.Extensions
{
    public static class MaintanenceMiddlewareExtension
    {
        public static IApplicationBuilder UseMaintenanceMode(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MaintenanceMiddleWare>();
        }
    }
}
