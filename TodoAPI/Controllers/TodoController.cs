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

    [HttpGet("{todoId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> GetById([FromRoute] QueryTodoRequest request)
    {
        return Results.Ok();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> InsertTodo([FromBody] PostTodoRequest request)
    {
        var result = await this._todoService.InsertTodo(request);
        return Results.Ok(result);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<TodoController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
