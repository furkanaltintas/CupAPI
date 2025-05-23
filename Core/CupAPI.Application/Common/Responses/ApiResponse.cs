using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;

public sealed record ApiResponse<T>(
    bool Success,
    string Message = "",
    T? Data = default,
    ErrorCodeEnum ErrorCode = ErrorCodeEnum.None,
    string ErrorCodeMessage = "")
{
    public static ApiResponse<T> SuccessResult(T data, string message = Messages.General.OperationSuccessful)
        => new(
            true,                                   // İşlem başarılı
            message,                                // Başarı mesajı (default: "İşlem başarılı.")
            data,                                   // Döndürülecek veri
            ErrorCodeEnum.None,                      // Hata kodu yok
            ErrorCodeEnum.None.ToString()            // Hata kodu mesajı boş
        );

    public static ApiResponse<T> SuccessNoDataResult(string message = Messages.General.OperationSuccessful)
        => new(
            true,                                   // İşlem başarılı
            message,                                // Başarı mesajı (default: "İşlem başarılı.")
            default,                                // Veri yok (null veya varsayılan) || İşlem başarılı olup data yollanmayacak işlemler de kullanılacak. Örnek: Ekleme işlemlerinde
            ErrorCodeEnum.None,                      // Hata kodu yok
            ErrorCodeEnum.None.ToString()            // Hata kodu mesajı boş
        );

    public static ApiResponse<T> SuccessEmptyDataResult(T data, string message = Messages.General.DataIsEmpty, ErrorCodeEnum errorCode = ErrorCodeEnum.EmptyData)
        => new(
            true,                                   // İşlem başarılı ancak veri boş
            message,                                // Başarı mesajı
            data,                                   // Boş veri
            errorCode,                              // Özel hata kodu (default: EmptyData)
            errorCode.ToString()                     // Hata kodunun string temsili
        );

    public static ApiResponse<T> Fail(string message, ErrorCodeEnum errorCode = ErrorCodeEnum.Exception)
        => new(
            false,                                  // İşlem başarısız
            message,                                // Hata mesajı
            default,                                // Veri yok (null veya varsayılan)
            errorCode,                              // Hata kodu
            errorCode.ToString()                     // Hata kodunun string temsili
        );

}
