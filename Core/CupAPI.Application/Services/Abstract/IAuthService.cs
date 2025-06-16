using CupAPI.Application.Dtos.AuthDtos;

namespace CupAPI.Application.Services.Abstract;

public interface IAuthService
{
    Task<TokenResponseDto> RegisterAsync(RegisterDto dto);
    Task<TokenResponseDto> RegisterCustomerAsync(RegisterDto dto);
    Task<TokenResponseDto> LoginAsync(LoginDto dto);
}