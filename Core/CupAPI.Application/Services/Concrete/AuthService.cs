using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Common.Helpers;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.IdentityModel.Tokens;

namespace CupAPI.Application.Services.Concrete;

public sealed class AuthService(
    TokenHelper tokenHelper) : IAuthService
{
    public async Task<ApiResponse<string>> GenerateToken(TokenDto tokenDto)
    {
        if (string.IsNullOrWhiteSpace(tokenDto.Email)) return ApiResponse<String>.Fail(Messages.Auth.EmailCannotBeEmpty, ErrorCodeEnum.ValidationError);

        try
        {
            String token = await tokenHelper.GenerateToken(tokenDto);
            return ApiResponse<String>.SuccessResult(token, Messages.Auth.TokenCreated);
        }
        catch (SecurityTokenException ex)
        {
            // Log: Token üretim hatası
            return ApiResponse<string>.Fail(Messages.Auth.TokenGenerationFailed, ErrorCodeEnum.Security);
        }
        catch (ArgumentException ex)
        {
            // Log: Geçersiz parametre
            return ApiResponse<string>.Fail(Messages.General.InvalidParameter, ErrorCodeEnum.ValidationError);
        }
        catch (Exception ex)
        {
            // Log: Beklenmeyen hata
            return ApiResponse<string>.Fail(Messages.General.UnexpectedErrorOccurred, ErrorCodeEnum.Unknown);
        }
    }
}