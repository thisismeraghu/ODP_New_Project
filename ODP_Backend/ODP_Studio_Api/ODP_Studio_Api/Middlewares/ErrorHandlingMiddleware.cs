using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ODP_Studio_Api.Domain.Exceptions;

namespace ODP_Studio_Api.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string result;
            string logMessage;
            LogLevel logLevel;

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new { error = validationException.Message, errors = validationException.Errors });
                    logLevel = LogLevel.Warning;
                    logMessage = $"Validation error: {validationException.Message}";
                    break;

                case AuthenticationException authException:
                    statusCode = HttpStatusCode.Unauthorized;
                    result = JsonSerializer.Serialize(new { error = authException.Message });
                    logLevel = LogLevel.Warning;
                    logMessage = $"Authentication failure: {authException.Message}";
                    break;

                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new { error = notFoundException.Message });
                    logLevel = LogLevel.Warning;
                    logMessage = $"Resource not found: {notFoundException.Message}";
                    break;

                case UnauthorizedAccessException unauthorizedAccessException:
                    statusCode = HttpStatusCode.Forbidden;
                    result = JsonSerializer.Serialize(new { error = unauthorizedAccessException.Message });
                    logLevel = LogLevel.Warning;
                    logMessage = $"Forbidden access: {unauthorizedAccessException.Message}";
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    result = JsonSerializer.Serialize(new { error = "An unexpected error occurred." });
                    logLevel = LogLevel.Error;
                    logMessage = $"Unhandled exception: {exception.Message}";
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            // Log exception with appropriate severity
            _logger.Log(logLevel, exception, logMessage);

            await context.Response.WriteAsync(result);
        }
    }
}