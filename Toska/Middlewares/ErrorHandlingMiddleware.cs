using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Toska.Exceptions;
using Toska.Utility;

namespace Toska.Middlewares
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


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (BusinessException bex)
            {
                if (bex is DuplicateEmailException dex)
                {
                    _logger.LogWarning(
                        bex,
                        "Business validation failed for user creation with masked email {Email}",
                        MaskingHelper.MaskEmail(dex.Email));
                }
                else
                {
                    _logger.LogWarning(
                        bex,
                        "Business error occured: {ErrorCode}",
                        bex.ErrorCode);
                }
                await WriteProblemDetails(
                    context,
                    bex.StatusCode,
                    "Validation error",
                    bex.UserMessage,
                    bex.ErrorCode ?? ErrorCodes.ValidationError);

            }
            catch (DbUpdateConcurrencyException dex)
            {
                _logger.LogWarning(
                    dex,
                    "Concurrency error");

                await WriteProblemDetails(
                    context,
                    StatusCodes.Status409Conflict,
                    "Conflict",
                    "The resource was updated by another request.",
                    ErrorCodes.ConcurrencyError);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Unhandled exception");

                await WriteProblemDetails(
                    context,
                    StatusCodes.Status500InternalServerError,
                    "Internal Server Error",
                    "An unexpected error occurred.",
                    ErrorCodes.InternalServerError);

            }
        }



        private static Task WriteProblemDetails(HttpContext context, int statusCode, string title, string detail, string errorCode)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = statusCode;

            var problem = new ProblemDetails()
            {
                Title = title,
                Status = statusCode,
                Detail = detail,
                Instance = context.TraceIdentifier
            };
            problem.Extensions["errorCode"] = errorCode;
            problem.Extensions["traceId"] = context.TraceIdentifier;

            return context.Response.WriteAsJsonAsync(problem);
        }




    }
}
