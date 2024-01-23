using Cotrucking.Domain.Enums;
using Cotrucking.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Cotrucking.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleCustomExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleCustomExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var errorResponse = new ErrorResponseModel();

            switch (exception)
            {
                case ResponseException ex:
                    errorResponse.Severity = ex.Severity;
                    errorResponse.Message = ex.Message;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "An error has occurred, Please try again";
                    errorResponse.Severity = Severity.Error;
                    break;
            }

            _logger.LogCritical(exception, "Error occured at {trace} because {message}", exception.StackTrace, exception.Message);
            httpContext.Response.ContentType = "application/json";
            exception = GetLastException(exception);
            var exceptionMessage = GetLastException(exception).Message;
            _logger.LogError(exception, "An error occurred at path {path}: {ErrorMessage} ", httpContext.Request.Path, exceptionMessage);
            var result = JsonSerializer.Serialize(errorResponse);
            await httpContext.Response.WriteAsync(result);
        }

        private static Exception GetLastException(Exception exception)
        {
            if (exception.InnerException == null)
                return exception;
            return GetLastException(exception.InnerException);
        }
    }
}
