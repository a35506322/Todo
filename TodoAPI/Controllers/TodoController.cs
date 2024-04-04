namespace Todo.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[AllowAnonymous]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    public TodoController(ITodoService todoService)
    {
        this._todoService = todoService;
    }

    /// <summary>
    /// 多筆查詢 Todo
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    [EndpointSpecificExample(typeof(TodoGetRequestExample), ExampleType = ExampleType.Request)]
    [EndpointSpecificExample(typeof(TodoGetResponseExample),
        ExampleType = ExampleType.Response,
        ResponseStatusCode = StatusCodes.Status200OK)]
    public async Task<IResult> Get([FromQuery] QueryTodoRequest request)
    {
        var result = await this._todoService.GetTodos(request);
        return Results.Ok(result);
    }

    /// <summary>
    /// 單筆新增 Todo
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    [EndpointSpecificExample(typeof(PostTodoRequestExample), ExampleType = ExampleType.Request)]
    [EndpointSpecificExample(typeof(InsertSuccessResponseExample),
        typeof(InsertFailResponseExample),
        ExampleType = ExampleType.Response, ResponseStatusCode = StatusCodes.Status200OK)]
    public async Task<IResult> InsertTodo([FromBody] PostTodoRequest request)
    {
        var result = await this._todoService.InsertTodo(request);
        return Results.Ok(result);
    }

    /// <summary>
    /// 修改 Todo 是否完成
    /// </summary>
    /// <param name="request"></param>
    /// <param name="todoId"></param>
    /// <returns></returns>
    [HttpPut("~/api/[controller]/UpdateTodoStatus/{todoId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    [EndpointSpecificExample(typeof(PutUpdateTodoStatusRequestExample), ExampleType = ExampleType.Request)]
    [EndpointSpecificExample(typeof(VaildDataErrorResponseExample),
        typeof(QueryNotFoundResponseExample),
        typeof(UpdateFailResponseExample),
        typeof(UpdateSuccessResponseExample),
        ExampleType = ExampleType.Response, ResponseStatusCode = StatusCodes.Status200OK)]

    public async Task<IResult> UpdateTodoStatus([FromBody] PutUpdateTodoStatusRequest request, [FromRoute] Guid todoId)
    {
        if (todoId != request.TodoId) return Results.Ok(ResponseExtension.Command.VaildDataError());
        var result = await this._todoService.UpdateTodoStatus(request);
        return Results.Ok(result);
    }

    /// <summary>
    /// 刪除 Todo
    /// </summary>
    /// <param name="todoId">PK</param>
    /// <returns></returns>
    [HttpDelete("{todoId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    [EndpointSpecificExample(typeof(QueryNotFoundResponseExample),
        typeof(DeleteFailResponseExample),
        typeof(DeleteSuccessResponseExample),
        ExampleType = ExampleType.Response, ResponseStatusCode = StatusCodes.Status200OK)]
    public async Task<IResult> Delete([FromRoute] Guid todoId)
    {
        var result = await this._todoService.DeleteTodo(todoId);
        return Results.Ok(result);
    }

    /// <summary>
    /// 修改 Todo 內容
    /// </summary>
    /// <param name="request"></param>
    /// <param name="todoId"></param>
    /// <returns></returns>
    [HttpPut("~/api/[controller]/UpdateTodoContent/{todoId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    [EndpointSpecificExample(typeof(PutUpdateTodoContentRequestExample), ExampleType = ExampleType.Request)]
    [EndpointSpecificExample(typeof(VaildDataErrorResponseExample),
        typeof(QueryNotFoundResponseExample),
        typeof(UpdateFailResponseExample),
        typeof(UpdateSuccessResponseExample),
        ExampleType = ExampleType.Response, ResponseStatusCode = StatusCodes.Status200OK)]
    public async Task<IResult> UpdateTodoContent([FromBody] PutUpdateTodoContentRequest request, [FromRoute] Guid todoId)
    {
        if (todoId != request.TodoId) return Results.Ok(ResponseExtension.Command.VaildDataError());
        var result = await this._todoService.UpdateTodo(request);
        return Results.Ok(result);
    }
}
