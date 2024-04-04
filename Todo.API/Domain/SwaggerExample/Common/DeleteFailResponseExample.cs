namespace Todo.API.Domain.SwaggerExample.Common;

[ExampleAnnotation(Name = "刪除失敗")]
public class DeleteFailResponseExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        return ResponseExtension.Command.DeleteFail();
    }
}

