using Microsoft.AspNetCore.Diagnostics;
using System.Net.Mime;
using System.Text.Json;
using TopiTopi.Application.Exceptions;

namespace TopiTopi.API.Extensions
{
    public static class GlobalExceptionHandler
    {
        public static void AddGlobalExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(exceptionHandler =>
            {
                exceptionHandler.Run(async context =>
                {
                    IExceptionHandlerPathFeature? exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature == null)
                    {
                        return;
                    }
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    if (exceptionHandlerPathFeature.Error is not AppHandledException exception)
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsync(string.Empty);
                        return;
                    }
                    context.Response.StatusCode = (int)exception.StatusCode;
                    string result = JsonSerializer.Serialize(new { error = exception.Message });
                    await context.Response.WriteAsync(result);
                });
            });
        }
    }
}
