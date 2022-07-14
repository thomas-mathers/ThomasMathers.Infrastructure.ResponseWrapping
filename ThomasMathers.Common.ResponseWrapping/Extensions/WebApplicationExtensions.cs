using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using ThomasMathers.Common.ResponseWrapping.Models;

namespace ThomasMathers.Common.ResponseWrapping.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void UseResponseWrappingExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    var ex = context.Features.Get<IExceptionHandlerFeature>();

                    if (ex != null && app.Environment.IsDevelopment())
                    {
                        await context.Response.WriteAsJsonAsync(new ApiResult 
                        {
                            ErrorCode = "CriticalError",
                            ErrorMessage = ex.Error.Message,
                            Value = ex.Error.StackTrace
                        });

                        return;
                    }

                    await context.Response.WriteAsJsonAsync(new ApiResult
                    {
                        ErrorCode = "CriticalError"
                    });
                });
            });
        }
    }
}
