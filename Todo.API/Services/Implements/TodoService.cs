namespace Todo.API.Services.Implements;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;
    public TodoService(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<ResultResponse> DeleteTodo(Guid todoId)
    {
        var todo = await this._todoRepository.GetByTodoIdAsync(todoId);
        if (todo is null) return ResponseExtension.Command.QueryNotFound(todoId.ToString());

        var result = await this._todoRepository.DeleteByTodoIdAsync(todoId);
        if (!result) return ResponseExtension.Command.DeleteFail();

        return ResponseExtension.Command.DeleteFail();
    }

    public async Task<ResultResponse> GetTodos(QueryTodoRequest request)
    {
        var entity = this._mapper.Map<TodoEntity>(request);
        var result = await this._todoRepository.GetAsync(entity);
        return ResponseExtension.Query.QuerySuccess(result);
    }

    public async Task<ResultResponse> InsertTodo(PostTodoRequest request)
    {
        var entity = this._mapper.Map<TodoEntity>(request);
        var result = await this._todoRepository.InsertAsync(entity);

        if (!result) return ResponseExtension.Command.InsertFail();

        return ResponseExtension.Command.InsertSuccess();
    }

    public async Task<ResultResponse> UpdateTodo(PutUpdateTodoContentRequest request)
    {
        var todo = await this._todoRepository.GetByTodoIdAsync(request.TodoId);
        if (todo is null) return ResponseExtension.Command.QueryNotFound(request.TodoId.ToString());

        var entity = this._mapper.Map<TodoEntity>(request);
        var result = await this._todoRepository.UpdateTodoByTodoIdAsync(entity);
        if (!result) return ResponseExtension.Command.UpdateFail();

        return ResponseExtension.Command.UpdateSuccess();
    }

    public async Task<ResultResponse> UpdateTodoStatus(PutUpdateTodoStatusRequest request)
    {
        var todo = await this._todoRepository.GetByTodoIdAsync(request.TodoId);
        if (todo is null) return ResponseExtension.Command.QueryNotFound(request.TodoId.ToString());

        var entity = this._mapper.Map<TodoEntity>(request);
        var result = await this._todoRepository.UpdateTodoStatusByTodoIdAsync(entity);
        if (!result) return ResponseExtension.Command.UpdateFail();

        return ResponseExtension.Command.UpdateSuccess();
    }
}
