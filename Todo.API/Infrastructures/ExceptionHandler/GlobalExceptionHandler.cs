﻿namespace Todo.API.Infrastructures.ExceptionHandler;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IHostEnvironment _env;
    public GlobalExceptionHandler(IHostEnvironment env)
    {
        this._env = env;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var title = _env.IsDevelopment() ? "An error occured: " + exception.Message : "An error occured";
        var details = _env.IsDevelopment() ? exception.ToString() : null;

        var problemDetails = new ProblemDetails
        {
            Type = exception.GetType().Name,
            Status = StatusCodes.Status500InternalServerError,
            Title = title,
            Detail = details,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"

        };
        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
        if (traceId != null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }

        httpContext.Response.StatusCode = problemDetails.Status.Value;


        await httpContext.Response
            .WriteAsJsonAsync(ResponseExtension.Exception.UnexpectedException(problemDetails), cancellationToken);

        return true;
    }
}