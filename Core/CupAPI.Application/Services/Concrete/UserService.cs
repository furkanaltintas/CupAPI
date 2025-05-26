using CupAPI.Application.Common.Enums;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using FluentValidation;

namespace CupAPI.Application.Services.Concrete;

public class UserService(
    IUserRepository userRepository,
    IValidator<RegisterDto> registerValidator) : IUserService
{
    public async Task<ApiResponse<string>> LoginAsync(LoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user is null) return ApiResponse<String>.Fail("E-posta adresi bulunamadı", ErrorCodeEnum.NotFound);

        var result = await userRepository.LoginAsync(loginDto, user);
        if (!result.Succeeded) return ApiResponse<String>.Fail("Email veya şifre hatalı", ErrorCodeEnum.NotFound);

        return ApiResponse<String>.SuccessNoDataResult("Giriş başarılı");
    }

    public async Task<ApiResponse<string>> RegisterAsync(RegisterDto registerDto)
    {
        try
        {
            var validate = await registerValidator.ValidateAsync(registerDto);
            if (!validate.IsValid) return ApiResponse<String>.Fail("", ErrorCodeEnum.ValidationError);

            var result = await userRepository.RegisterAsync(registerDto);
            if (result.Succeeded) return ApiResponse<String>.SuccessNoDataResult("Kayıt işlemi başarılı bir şekilde gerçekleşmiştir");
            else return ApiResponse<String>.Fail("", ErrorCodeEnum.NotFound);
        }
        catch
        {
            return ApiResponse<String>.Fail("", ErrorCodeEnum.NotFound);
        }
    }

    public async Task<ApiResponse<string>> LogoutAsync()
    {
        await userRepository.LogoutAsync();
        return ApiResponse<String>.SuccessNoDataResult("Çıkış işlemi başarılı");
    }
}
