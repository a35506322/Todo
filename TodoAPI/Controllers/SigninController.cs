namespace Todo.API.Controllers;

[Route("/api/[controller]/[action]")]
[ApiController]
[AllowAnonymous]
public class SigninController : ControllerBase
{
    private readonly JWTHelper _jWTHelper;
    public SigninController(JWTHelper jWTHelper)
    {
        this._jWTHelper = jWTHelper;
    }


    [HttpPost]
    public async Task<IResult> SignIn([FromBody] PostSignInRequest request)
    {
        if (request is not { Account: "Admin", Password: "=-09poiu" }) return Results.Ok(ResponseExtension.Verify.LoginVerificationError());
        return Results.Ok(ResponseExtension.Command.SiginSuccess(this._jWTHelper.GenerateToken()));
    }
}
