namespace Todo.API.Services.Interfaces;

public interface ITodoService
{
    public Task<ResultResponse> InsertTodo(PostTodoRequest request);
}
