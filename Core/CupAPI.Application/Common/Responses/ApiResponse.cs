using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;

public sealed record ApiResponse<T>(
    bool Success,
    string Message = "",
    T? Data = default,
    ErrorCodeEnum ErrorCode = ErrorCodeEnum.None)
{
    public static ApiResponse<T> SuccessResult(T data, string message = Messages.General.OperationSuccessful)
        => new(true, message, data);

    public static ApiResponse<T> SuccessNoDataResult(string message = Messages.General.OperationSuccessful)
        => new(true, message);

    public static ApiResponse<T> SuccessEmptyDataResult(T data, string message = Messages.General.OperationSuccessful, ErrorCodeEnum errorCode = ErrorCodeEnum.EmptyData)
    => new(true, message, data);

    public static ApiResponse<T> Fail(string message, ErrorCodeEnum errorCode = ErrorCodeEnum.Exception)
        => new(false, message, default, errorCode);
}