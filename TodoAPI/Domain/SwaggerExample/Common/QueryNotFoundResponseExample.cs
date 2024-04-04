namespace Todo.API.Domain.SwaggerExample.Common;


[ExampleAnnotation(Name = "查無此資料")]
public class QueryNotFoundResponseExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        return ResponseExtension.Command.QueryNotFound("這邊會帶PK");
    }
}
