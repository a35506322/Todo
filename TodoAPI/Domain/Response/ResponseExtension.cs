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
        public static ResultResponse InsertSuccess() => new ResultResponse(ReturnMessage: "新增成功");
        public static ResultResponse InsertFail() => new ResultResponse(ReturnCode: Enum.ReturnCodeEnum.DBCommandFail, ReturnMessage: "新增失敗");
    }

    public static class Verify
    {
        public static ResultResponse LoginVerificationError() => new ResultResponse(ReturnCode: Enum.ReturnCodeEnum.UnAuth, ReturnMessage: "登入失敗");

    }

    public static class Exception
    {
        public static ResultResponse GlobalException(ProblemDetails problemDetails) => new ResultResponse(ReturnCode: Enum.ReturnCodeEnum.ServerError, Data: problemDetails);
        public static ResultResponse BadRequest(ProblemDetails problemDetails) => new ResultResponse(ReturnCode: Enum.ReturnCodeEnum.VaildDataError, Data: problemDetails);

    }
}
