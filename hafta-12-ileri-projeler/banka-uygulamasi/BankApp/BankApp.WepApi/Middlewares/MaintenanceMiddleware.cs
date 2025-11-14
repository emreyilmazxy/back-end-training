using BankApp.Business.Operations.Setting;

namespace BankApp.WepApi.Middlewares
{
    public class MaintenanceMiddleware
    {
        private readonly RequestDelegate _next;

        public MaintenanceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task  InvokeAsync(HttpContext context)
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
               
                var userRole = context.User.FindFirst("role")?.Value;

                if (string.IsNullOrEmpty(userRole) || userRole != "Admin")
                {
                    context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    await context.Response.WriteAsync("Site bakımda, sadece admin giriş yapabilir.");
                    return;
                }
            }

            
            await _next(context);
        }


    } // end of class 
}
