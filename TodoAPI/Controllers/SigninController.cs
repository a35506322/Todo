using Todo.API.Domain.SwaggerExample.SignIn;

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


    /// <summary>
    /// 登入
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
    [EndpointSpecificExample(typeof(PostSignInRequestExample), ExampleType = ExampleType.Request)]
    [EndpointSpecificExample(typeof(SiginSuccessResponseExample),
        typeof(LoginVerificationErrorResponseExample),
        ExampleType = ExampleType.Response,
        ResponseStatusCode = StatusCodes.Status200OK)]

    public async Task<IResult> SignIn([FromBody] PostSignInRequest request)
    {
        if (request is not { Account: "Admin", Password: "=-09poiu" }) return Results.Ok(ResponseExtension.Verify.LoginVerificationError());
        return Results.Ok(ResponseExtension.Command.SiginSuccess(this._jWTHelper.GenerateToken()));
    }
}
