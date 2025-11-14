namespace BankApp.WepApi.Middlewares.Exentions
{
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }// end of class GlobalExceptionMiddlewareExtensions
}
