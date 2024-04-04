namespace Todo.API.Domain.SwaggerExample.SignIn;

public class PostSignInRequestExample : IExampleProvider<PostSignInRequest>
{
    public PostSignInRequest GetExample()
    {
        return new PostSignInRequest("Admin", "=-09poiu");
    }
}
