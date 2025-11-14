namespace BankApp.WepApi.Middlewares.Exentions
{
    public static class MaintanenceMiddlewareExtension
    {
        public static IApplicationBuilder UseMaintenanceMode(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MaintenanceMiddleware>();
        }
    }
}
