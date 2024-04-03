namespace Todo.API.Domain.SwaggerExample.Todo;

public class TodoGetRequestExample : IExampleProvider<QueryTodoRequest>
{
    public QueryTodoRequest GetExample()
    {
        return new QueryTodoRequest() { Name = "測試員" };
    }
}
