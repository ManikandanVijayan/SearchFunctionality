using SearchFunctionality.Models;
using System.Net;

namespace SearchFunctionality
{
    /// <summary>
    /// Exception middleware
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Handling exception 
        /// </summary>
        /// <param name="next">next</param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Handling exception 
        /// </summary>
        /// <param name="httpContext">Context</param>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
                MoreDetails = exception.StackTrace
            }.ToString()); ;
        }
    }
}
