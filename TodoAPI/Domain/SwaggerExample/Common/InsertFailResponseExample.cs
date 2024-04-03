namespace Todo.API.Domain.SwaggerExample.Common;

[ExampleAnnotation(Name = "新增失敗")]
public class InsertFailResponseExample:IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        return ResponseExtension.Command.InsertFail();
    }
}
