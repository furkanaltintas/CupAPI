namespace CupAPI.Application.Dtos.ResponseDtos;

public enum ErrorCode
{
    None = 0,
    NotFound = 1,
    BadRequest = 2,
    Unauthorized = 3,
    Exception = 4,
    ValidationError = 5,
    Conflict = 6,
    Forbidden = 7
}