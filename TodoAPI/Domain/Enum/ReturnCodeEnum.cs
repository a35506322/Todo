﻿namespace Todo.API.Domain.Enum;

public enum ReturnCodeEnum
{
    Success = 2000,
    VaildDataError = 4000,
    QueryNotFound = 4001,
    UnAuth = 4002,
    ServerError = 5000,
    DBCommandFail = 5001,
}
