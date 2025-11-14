using OnlineShoppingApp.Business.Operations.Settings;

namespace OnlineShoppingApp.WebApi.Middlewares
{

    public class MaintenanceMiddleWare
    {
        private readonly RequestDelegate _next;
       
        public MaintenanceMiddleWare(RequestDelegate next )
        {
            _next = next;
           
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var _settingService = context.RequestServices.GetRequiredService<ISettingService>();
            bool maintananceMode = await _settingService.GetMaintenanceStateAsync();

            if (context.Request.Path.StartsWithSegments("/api/v1/auth/login")
             || context.Request.Path.StartsWithSegments("/api/v1/settings"))
            {
                await _next(context);
                return;
            }

            if (maintananceMode)
            {
                await context.Response.WriteAsync("Site bakımda, lütfen daha sonra tekrar deneyin.");
            }
            else
            {
                 await _next(context);
            }
        }
    }
}
