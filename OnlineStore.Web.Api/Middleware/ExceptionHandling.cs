using System.Net;
using Serilog;

namespace OnlineStore.Web.Api.Middleware
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate _next;

        public ExceptionHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unhandled Exception");
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            finally
            {
                await Log.CloseAndFlushAsync();
            }
        }
    }

    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandling>();
        }
    }
}
