namespace Todo.API.Domain.SwaggerExample.Common;

[ExampleAnnotation(Name = "意外狀況錯誤", ExampleType = ExampleType.Response)]
public class UnexpectedExceptionExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        Exception exception = new Exception("測試錯誤");
        var title = "An error occured: " + exception.Message;
        var details = exception.ToString();

        var problemDetails = new ProblemDetails
        {
            Type = exception.GetType().Name,
            Status = StatusCodes.Status500InternalServerError,
            Title = title,
            Detail = details,
            Instance = $"POST /Signin/Signin"

        };
        var traceId = Guid.NewGuid();
        if (traceId != null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }
        return ResponseExtension.Exception.UnexpectedException(problemDetails);
    }
}

