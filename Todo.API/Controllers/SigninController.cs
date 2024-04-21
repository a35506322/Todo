using Todo.API.Domain.SwaggerExample.SignIn;

namespace Todo.API.Controllers;

[Route("/api/[controller]/[action]")]
[ApiController]
[AllowAnonymous]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultResponse))]
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
    [EndpointSpecificExample(typeof(UnexpectedExceptionExample),
        ExampleType = ExampleType.Response,
        ResponseStatusCode = StatusCodes.Status500InternalServerError)]
    [EndpointSpecificExample(typeof(BadRequestExceptionExample),
        ExampleType = ExampleType.Response,
        ResponseStatusCode = StatusCodes.Status400BadRequest)]

    public async Task<IResult> SignIn([FromBody] PostSignInRequest request)
    {
        if (request is not { Account: "Admin", Password: "=-09poiu" }) return Results.Ok(ResponseExtension.Verify.LoginVerificationError());
        return Results.Ok(ResponseExtension.Command.SiginSuccess(this._jWTHelper.GenerateToken()));
    }
}
