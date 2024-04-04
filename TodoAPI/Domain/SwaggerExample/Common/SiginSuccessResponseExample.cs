namespace Todo.API.Domain.SwaggerExample.Common;


[ExampleAnnotation(Name = "登入成功")]
public class SiginSuccessResponseExample : IExampleProvider<ResultResponse>
{
    public ResultResponse GetExample()
    {
        string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJmMDk4OGFiMy0wYjI1LTRkYzgtYTMxMS0zOTM2MjE1YTk4MzIiLCJuYmYiOjE3MTIyMTQ0NjEsImV4cCI6MTcxMjI0MzI2MSwiaWF0IjoxNzEyMjE0NDYxLCJpc3MiOiJUb2RvIn0.hzH8WLq9JhlZCRYm5bSxZLxuJF842t_0WtNtRePGJOg";
        return ResponseExtension.Command.SiginSuccess(token);
    }
}
