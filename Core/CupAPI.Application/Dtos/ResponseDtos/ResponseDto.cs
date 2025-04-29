namespace CupAPI.Application.Dtos.ResponseDtos;

public class ResponseDto<T> where T : class
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public T? Data { get; init; }
    public ErrorCode ErrorCode { get; init; } = ErrorCode.None;

    public static ResponseDto<T> SuccessResult(T data, string message = "İşlem Başarılı.")
    {
        return new ResponseDto<T>
        {
            Success = true,
            Message = message,
            Data = data,
            ErrorCode = ErrorCode.None
        };
    }

    public static ResponseDto<T> Fail(string message, ErrorCode errorCode = ErrorCode.Exception)
    {
        return new ResponseDto<T>
        {
            Success = false,
            Message = message,
            Data = null,
            ErrorCode = errorCode
        };
    }
}