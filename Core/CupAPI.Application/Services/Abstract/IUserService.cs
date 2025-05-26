using CupAPI.Application.Dtos.AuthDtos;

namespace CupAPI.Application.Services.Abstract;

public interface IUserService
{
    Task<ApiResponse<String>> LoginAsync(LoginDto loginDto);
    Task<ApiResponse<String>> RegisterAsync(RegisterDto registerDto);
    Task<ApiResponse<String>> LogoutAsync();
    Task<bool> CheckUser(LoginDto loginDto);
}