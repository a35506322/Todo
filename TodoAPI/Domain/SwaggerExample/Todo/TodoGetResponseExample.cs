namespace Todo.API.Domain.SwaggerExample.Todo;

public class TodoGetResponseExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        var todos = new List<TodoEntity>()
        {
            new TodoEntity()
            {
                TodoId =  Guid.NewGuid(),
                Name = "Test",
                AddTime = DateTime.Now,
                CompleteTime = DateTime.Now,
                IsComplete = "Y",
                Title = "Test",
                TodoContent = "Test",
            }
        };
       return ResponseExtension.Query.QuerySuccess(todos);
    }
}
