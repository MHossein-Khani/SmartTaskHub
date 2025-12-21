using FluentValidation;
using System.Text.Json;

namespace SmartTaskHub.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(
            HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            // Default to 500
            context.Response.StatusCode =
                StatusCodes.Status500InternalServerError;

            object response = new { error = exception.Message };

            // If it's a Validation Error, make it a 400
            if (exception is ValidationException validationException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                response = new
                {
                    error = "Validation Failed",
                    details = validationException.Errors.Select(e => e.ErrorMessage)
                };
            }

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
