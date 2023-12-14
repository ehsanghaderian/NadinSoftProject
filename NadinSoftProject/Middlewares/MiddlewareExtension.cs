using Microsoft.AspNetCore.Builder;
using NadinSoftProject.Host.Middlewares;

namespace Fino.SahaWarranty.Host.Activator.MiddleWare
{
    public static class MiddlewareExtension
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
