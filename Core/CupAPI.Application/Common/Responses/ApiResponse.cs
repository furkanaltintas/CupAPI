using CupAPI.Application.Common.Enums;
using CupAPI.Domain.Entities;

public sealed record ApiResponse<T>(
    bool Success,
    string Message = "",
    T? Data = default,
    ErrorCodeEnum ErrorCode = ErrorCodeEnum.None)
{
    public static ApiResponse<T> SuccessResult(T data, string message = "İşlem Başarılı.")
        => new(true, message, data);

    public static ApiResponse<T> SuccessNoDataResult(string message = "İşlem Başarılı.")
        => new(true, message);

    public static ApiResponse<T> Fail(string message, ErrorCodeEnum errorCode = ErrorCodeEnum.Exception)
        => new(false, message, default, errorCode);
}