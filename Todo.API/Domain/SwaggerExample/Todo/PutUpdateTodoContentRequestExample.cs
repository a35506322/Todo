namespace Todo.API.Domain.SwaggerExample.Todo;

public class PutUpdateTodoContentRequestExample : IExampleProvider<PutUpdateTodoContentRequest>
{
    public PutUpdateTodoContentRequest GetExample()
    {
        return new PutUpdateTodoContentRequest()
        {
            Name = "測試員",
            Title = "寫作業",
            TodoContent = "必須完成人生學報告",
            TodoId = Guid.NewGuid(),
        };
    }
}
