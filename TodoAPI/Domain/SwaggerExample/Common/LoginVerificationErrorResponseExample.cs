namespace Todo.API.Domain.SwaggerExample.Common;

[ExampleAnnotation(Name = "登入失敗")]
public class LoginVerificationErrorResponseExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        return ResponseExtension.Verify.LoginVerificationError();
    }
}

