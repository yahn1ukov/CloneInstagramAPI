using CloneInstagramAPI.Application.Common.Exception.Base;
using System.Net;
using System.Text.Json;

namespace CloneInstagramAPI.Api.Middleware
{
    public class ErrorHandlingMiddlware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException exception)
            { 
                await HandleExceptionAsync(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, CustomException exception)
        {
            var code = exception.Code switch
            {
                400 => HttpStatusCode.BadRequest,
                404 => HttpStatusCode.NotFound,
                409 => HttpStatusCode.Conflict,
                _ => HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(
                new 
                { 
                    code = code, 
                    message = exception.Message, 
                    timestamp = DateTime.Now 
                }
            );
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}