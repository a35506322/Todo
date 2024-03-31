namespace Todo.API.Domain.Response;

public class ResponseExtension
{
    public static class Query
    {
        public static ResultResponse QuerySuccess(object data) => new ResultResponse(ReturnMessage: "查詢成功", Data: data);
    }

    public static class Post
    {
        public static ResultResponse SiginSuccess(string token) => new ResultResponse(ReturnMessage: "登入成功", Data: token);
    }
}
