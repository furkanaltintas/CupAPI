using CupAPI.Application.Common.Enums;

namespace CupAPI.Application.Common.Responses;

public class ApiResponse<T> where T : class
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public T? Data { get; init; }
    public ErrorCodeEnum ErrorCode { get; init; } = ErrorCodeEnum.None; 

    public static ApiResponse<T> SuccessResult(T data, string message = "İşlem Başarılı.")
    {
        return new ApiResponse<T>
        {
            Success = true,
            Message = message,
            Data = data,
            ErrorCode = ErrorCodeEnum.None
        };
    }

    public static ApiResponse<T> SuccessNoDataResult(string message = "İşlem Başarılı.")
    {
        return new ApiResponse<T>
        {
            Success = true,
            Message = message,
            Data = null,
            ErrorCode = ErrorCodeEnum.None
        };
    }

    public static ApiResponse<T> Fail(string message, ErrorCodeEnum errorCode = ErrorCodeEnum.Exception)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message,
            Data = null,
            ErrorCode = errorCode
        };
    }
}