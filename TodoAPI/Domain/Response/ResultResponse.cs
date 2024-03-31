using Todo.API.Domain.Enum;

namespace Todo.API.Domain.Response;

public record ResultResponse(ReturnCodeEnum ReturnCode = ReturnCodeEnum.Success, string ReturnMessage = "", Object Data = null);
