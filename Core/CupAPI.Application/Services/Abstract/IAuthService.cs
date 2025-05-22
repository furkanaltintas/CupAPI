using CupAPI.Application.Dtos.AuthDtos;

namespace CupAPI.Application.Services.Abstract;

public interface IAuthService
{
    Task<ApiResponse<String>> GenerateToken(TokenDto tokenDto);
}