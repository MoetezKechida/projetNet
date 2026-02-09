using projetNet.DTOs.Common;
using projetNet.Exceptions;
using System.Net;
using System.Text.Json;

namespace projetNet.Middleware;


public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionHandlingMiddleware> logger,
        IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
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
        // Log the exception
        _logger.LogError(exception, "An error occurred: {Message}", exception.Message);
        
        // Create error response based on exception type
        var errorResponse = exception switch
        {
            NotFoundException notFound => new ErrorResponse
            {
                Status = StatusCodes.Status404NotFound,
                Message = notFound.Message,
                TraceId = context.TraceIdentifier
            },
            UnauthorizedException unauthorized => new ErrorResponse
            {
                Status = StatusCodes.Status403Forbidden,
                Message = unauthorized.Message,
                TraceId = context.TraceIdentifier
            },
            Exceptions.ValidationException validation => new ErrorResponse
            {
                Status = StatusCodes.Status400BadRequest,
                Message = "One or more validation errors occurred",
                Errors = validation.Errors.Select(e => new ErrorDetail
                {
                    Field = e.Key,
                    Message = string.Join(", ", e.Value)
                }),
                TraceId = context.TraceIdentifier
            },
            BusinessRuleViolationException businessRule => new ErrorResponse
            {
                Status = StatusCodes.Status400BadRequest,
                Message = businessRule.Message,
                TraceId = context.TraceIdentifier
            },
            InvalidOperationException invalidOp => new ErrorResponse
            {
                Status = StatusCodes.Status400BadRequest,
                Message = invalidOp.Message,
                TraceId = context.TraceIdentifier
            },
            _ => new ErrorResponse
            {
                Status = StatusCodes.Status500InternalServerError,
                Message = _env.IsDevelopment() 
                    ? exception.Message 
                    : "An unexpected error occurred. Please try again later.",
                TraceId = context.TraceIdentifier
            }
        };
        
        // Set response status code and content type
        context.Response.StatusCode = errorResponse.Status;
        context.Response.ContentType = "application/json";
        
        // Serialize and write response
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        var json = JsonSerializer.Serialize(errorResponse, options);
        await context.Response.WriteAsync(json);
    }
}

public static class GlobalExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandling(
        this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }
}
