using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Dtos.UserDtos;

namespace CupAPI.Application.Services.Abstract;

public interface IAuthService
{
    Task<ApiResponse<String>> GenerateToken(TokenDto tokenDto);
    Task<ApiResponse<String>> LoginAsync(LoginDto loginDto);
    Task<ApiResponse<String>> LogoutAsync();
}