namespace Todo.API.Domain.SwaggerExample.Common;

[ExampleAnnotation(Name = "更新失敗")]
public class UpdateFailResponseExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        return ResponseExtension.Command.UpdateFail();
    }
}
