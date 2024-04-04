namespace Todo.API.Domain.SwaggerExample.Common;

[ExampleAnnotation(Name = "刪除成功")]
public class DeleteSuccessResponseExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        return ResponseExtension.Command.DeleteSuccess();
    }
}

