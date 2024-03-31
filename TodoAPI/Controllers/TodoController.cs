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

    // GET: api/<TodoController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<TodoController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    public async Task<IResult> InsertTodo([FromBody] PostTodoRequest request)
    {
        var result = await this._todoService.InsertTodo(request);
        return Results.Ok(result);
    }

    // PUT api/<TodoController>/5
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
