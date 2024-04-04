namespace Todo.API.Domain.SwaggerExample.Common;

[ExampleAnnotation(Name = "驗證錯誤")]
public class VaildDataErrorResponseExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        return ResponseExtension.Command.VaildDataError();
    }
}

