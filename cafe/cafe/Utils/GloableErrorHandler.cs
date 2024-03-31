using cafe.Domain.Common;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace cafe.Utils
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    await context.Response.WriteAsync(new BaseResponse<string>()
                    {
                        data = "somthing wnet wrong tray agian later",
                        statusCode = context.Response.StatusCode,
                        message = $"Internal Server Error.{contextFeature.Error.Data}"
                    }.ToString());
                });
            });

        }
    }
}