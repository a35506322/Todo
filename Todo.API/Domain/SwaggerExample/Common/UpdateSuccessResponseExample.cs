namespace Todo.API.Domain.SwaggerExample.Common;

[ExampleAnnotation(Name = "更新成功")]
public class UpdateSuccessResponseExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        return ResponseExtension.Command.UpdateSuccess();
    }
}
