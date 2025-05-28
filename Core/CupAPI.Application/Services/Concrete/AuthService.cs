using CupAPI.Application.Common.Helpers.Jwt.Abstract;
using CupAPI.Application.Common.Helpers.PasswordHasher.Abstract;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Services.Concrete;

public sealed class AuthService(
    IUserRepository userRepository, IJwtService jwtService, IPasswordHasher passwordHasher) : IAuthService
{
    public TokenResponseDto GenerateTokenAsync(User user)
    {
        TokenResponseDto token = jwtService.CreateToken(user);
        return token;
    }

    public async Task<TokenResponseDto> LoginAsync(LoginDto dto)
    {
        User user = await userRepository.GetByEmailAsync(dto.Email) ?? throw new Exception("User not found.");

        if (!passwordHasher.Verify(dto.Password, user.PasswordHash))
            throw new Exception("Invalid password.");

        return GenerateTokenAsync(user);
    }

    public async Task<TokenResponseDto> RegisterAsync(RegisterDto dto)
    {
        if (await userRepository.ExistsByEmailAsync(dto.Email))
            throw new Exception("Email already exists.");

        var hashedPassword = passwordHasher.Hash(dto.Password);
        var user = new User
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Email = dto.Email,
            Phone = dto.Phone,
            PasswordHash = hashedPassword
        };

        await userRepository.AddAsync(user);

        return GenerateTokenAsync(user);
    }
}