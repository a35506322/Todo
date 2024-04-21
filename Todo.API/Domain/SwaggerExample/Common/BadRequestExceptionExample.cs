namespace Todo.API.Domain.SwaggerExample.Common;

[ExampleAnnotation(Name = "伺服器驗證錯誤", ExampleType = ExampleType.Response)]
public class BadRequestExceptionExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        return ResponseExtension.Exception.BadRequest(new { password = new string[] { "The Password field is required." } });
    }
}

