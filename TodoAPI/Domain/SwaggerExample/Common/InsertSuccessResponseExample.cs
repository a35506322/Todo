namespace Todo.API.Domain.SwaggerExample.Common;

[ExampleAnnotation(Name = "新增成功")]
public class InsertSuccessResponseExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        return ResponseExtension.Command.InsertSuccess();
    }
}
