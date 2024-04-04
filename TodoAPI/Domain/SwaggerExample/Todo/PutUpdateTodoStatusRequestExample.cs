namespace Todo.API.Domain.SwaggerExample.Todo;

public class PutUpdateTodoStatusRequestExample : IExampleProvider<PutUpdateTodoStatusRequest>
{
    public PutUpdateTodoStatusRequest GetExample()
    {
        return new PutUpdateTodoStatusRequest()
        {
            IsComplete = "Y",
            TodoId = Guid.NewGuid()
        };
    }
}

