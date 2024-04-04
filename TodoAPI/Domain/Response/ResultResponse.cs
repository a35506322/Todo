namespace Todo.API.Domain.Response;

public record ResultResponse(ReturnCodeEnum ReturnCode = ReturnCodeEnum.Success, string ReturnMessage = "", object ReturnData = null);
