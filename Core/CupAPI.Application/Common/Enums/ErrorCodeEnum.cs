namespace CupAPI.Application.Common.Enums;

public enum ErrorCodeEnum
{
    None = 0, // Boş bir değer gönderilmek istendiğinde
    NotFound = 1,
    BadRequest = 2,
    Unauthorized = 3,
    Exception = 4,
    ValidationError = 5,
    Conflict = 6,
    Forbidden = 7,
    EmptyData = 8, // Veritabanında veri yok ise kullanılacak
    Security = 9,  // Güvenlik hataları için
    Unknown = 10   // Beklenmeyen genel hatalar için
}