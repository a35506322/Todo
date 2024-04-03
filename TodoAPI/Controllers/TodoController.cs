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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> Get([FromQuery] QueryTodoRequest request)
    {
        var result = await this._todoService.GetTodos(request);
        return Results.Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> InsertTodo([FromBody] PostTodoRequest request)
    {
        var result = await this._todoService.InsertTodo(request);
        return Results.Ok(result);
    }

    [HttpPut("~/api/[controller]/UpdateTodoStatus/{todoId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> UpdateTodoStatus([FromBody] PutUpdateTodoStatusRequest request, [FromRoute] Guid todoId)
    {
        if(todoId != request.TodoId) return Results.Ok(ResponseExtension.Command.VaildDataError());
        var result = await this._todoService.UpdateTodoStatus(request); 
        return Results.Ok(result);
    }

    [HttpDelete("{todoId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> Delete([FromRoute] Guid todoId)
    {
        var result = await this._todoService.DeleteTodo(todoId);
        return Results.Ok(result);
    }

    [HttpPut("~/api/[controller]/UpdateTodoContent/{todoId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> UpdateTodoContent([FromBody] PutUpdateTodoContentRequest request, [FromRoute] Guid todoId)
    {
        if (todoId != request.TodoId) return Results.Ok(ResponseExtension.Command.VaildDataError());
        var result = await this._todoService.UpdateTodo(request);
        return Results.Ok(result);
    }
}
