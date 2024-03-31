namespace Todo.API.Domain.Enum;

public enum ReturnCodeEnum
{
    Success = 2000,
    VaildDataError = 4000,
    UnAuth = 4001,
    ServerError = 5000,
    DBCommandFail = 5001,
}
