namespace CupAPI.Application.Common.Enums;

public enum ErrorCodeEnum
{
    None = 0, // Veri var ama bu hata değil
    NotFound = 1,
    BadRequest = 2,
    Unauthorized = 3,
    Exception = 4,
    ValidationError = 5,
    Conflict = 6,
    Forbidden = 7,
    EmptyData = 8 // Veri bulunamadı ama bu hata değil
}