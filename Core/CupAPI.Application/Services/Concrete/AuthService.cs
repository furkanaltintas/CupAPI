using CupAPI.Application.Common.Helpers.Jwt.Abstract;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

public class AuthService(
    IUserService userService,
    SignInManager<AppIdentityUser> signInManager,
    IJwtService jwtService) : IAuthService
{
    public async Task<TokenResponseDto> RegisterAsync(RegisterDto dto)
    {
        bool exists = await userService.EmailExistsAsync(dto.Email);
        if (exists) throw new Exception("Bu e-posta ile zaten kayıtlı bir kullanıcı var.");

        IdentityResult result = await userService.CreateUserAsync(dto);
        if (!result.Succeeded)
        {
            String errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Kullanıcı oluşturulamadı: {errors}");
        }

        // İsteğe bağlı rol ataması:
        await userService.AssignRoleAsync(dto.Email, "User");

        AppIdentityUser user = await userService.GetByEmailAsync(dto.Email)
            ?? throw new Exception("Kullanıcı oluşturuldu ancak erişilemedi.");

        return jwtService.CreateToken(user);
    }

    public async Task<TokenResponseDto> LoginAsync(LoginDto dto)
    {
        AppIdentityUser user = await userService.GetByEmailAsync(dto.Email)
            ?? throw new Exception("Kullanıcı bulunamadı.");

        SignInResult result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if (!result.Succeeded) throw new Exception("Geçersiz şifre.");

        return jwtService.CreateToken(user);
    }
}
