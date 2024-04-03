namespace Todo.API.Services.Interfaces;

public interface ITodoService
{
    public Task<ResultResponse> GetTodos(QueryTodoRequest request);
    public Task<ResultResponse> InsertTodo(PostTodoRequest request);
    public Task<ResultResponse> UpdateTodoStatus(PutUpdateTodoStatusRequest request);
    public Task<ResultResponse> DeleteTodo(Guid todoId);
    public Task<ResultResponse> UpdateTodo(PutUpdateTodoContentRequest request);
}
