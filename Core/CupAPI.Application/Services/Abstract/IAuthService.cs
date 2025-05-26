using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Services.Abstract;

public interface IAuthService
{
    Task<TokenResponseDto> RegisterAsync(RegisterDto dto);
    Task<TokenResponseDto> LoginAsync(LoginDto dto);
    Task<TokenResponseDto> GenerateTokenAsync(User user);
}