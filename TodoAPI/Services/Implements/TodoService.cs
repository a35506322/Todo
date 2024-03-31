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

    public async Task<ResultResponse> InsertTodo(PostTodoRequest request)
    {
        var entity = this._mapper.Map<TodoEntity>(request);
        var result = await this._todoRepository.InsertAsyc(entity);

        if (!result) return ResponseExtension.Post.InsertFail();

        return ResponseExtension.Post.InsertSuccess();
    }
}
