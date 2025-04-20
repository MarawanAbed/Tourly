
using System.Net;
using System.Text.Json;

namespace TravelBookingPortal.API.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Pass the request to the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An unhandled exception occurred while processing the request.");

                // Handle the exception and return a response
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Determine the status code based on the exception type
            var statusCode = exception switch
            {
                ArgumentException => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };

            // Set the response status code and content type
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            // Check if the environment is development
            var isDevelopment = context.RequestServices.GetRequiredService<IWebHostEnvironment>().IsDevelopment();

            // Create the response object
            var response = new
            {
                StatusCode = statusCode,
                Message = statusCode == (int)HttpStatusCode.InternalServerError
                    ? "An unexpected error occurred. Please try again later."
                    : exception.Message, // Use exception message for non-500 errors
                Details = isDevelopment ? exception.Message : null // Show details only in development
            };

            // Serialize the response to JSON
            var jsonResponse = JsonSerializer.Serialize(response);

            // Write the response to the HTTP response body
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}