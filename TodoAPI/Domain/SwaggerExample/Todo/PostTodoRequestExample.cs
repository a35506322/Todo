namespace Todo.API.Domain.SwaggerExample.Todo;

public class PostTodoRequestExample : IExampleProvider<PostTodoRequest>
{
    public PostTodoRequest GetExample()
    {
        return new PostTodoRequest() 
        { 
            Name = "測試員", 
            Title = "吃飯", 
            TodoContent = "睡覺打咚咚" 
        };
    }
}

