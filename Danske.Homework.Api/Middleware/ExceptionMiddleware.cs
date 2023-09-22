using System.Net;
using Danske.Homework.Api.Models;
using Danske.Homework.Application.Exceptions;
using Newtonsoft.Json;

namespace Danske.Homework.Api.Middleware;

/// <summary>
/// Exception middleware is used to map application exceptions to appropriate status codes and format
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
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
        var statusCode = HttpStatusCode.InternalServerError;
        CustomValidationProblemDetails problem;
        switch (exception)
        {
            case InvalidInputException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomValidationProblemDetails
                {
                    Title = exception.Message,
                    Status = (int)statusCode,
                    Detail = exception.InnerException?.Message,
                    Type = nameof(InvalidInputException)
                };
                break;
            case FileNotFoundException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomValidationProblemDetails
                {
                    Title = exception.Message,
                    Status = (int)statusCode,
                    Detail = exception.InnerException?.Message,
                    Type = nameof(InvalidInputException)
                };
                break;
            default:
                problem = new CustomValidationProblemDetails
                {
                    Title = exception.Message,
                    Status = (int)statusCode,
                    Detail = exception.InnerException?.Message,
                    Type = nameof(HttpStatusCode.InternalServerError)
                };
                break;
        }
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsJsonAsync(problem);
    }
}