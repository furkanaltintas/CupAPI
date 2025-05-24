using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Dtos.UserDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

[AllowAnonymous] // Bu controller, authentication gerektirmez
public sealed class AuthController(IAuthService authService) : BaseApiController
{
    [HttpPost("generate-token")]
    public async Task<IActionResult> GenerateToken(TokenDto tokenDto)
    {
        var response = await authService.GenerateToken(tokenDto);
        return HandleResponse(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var response = await authService.LoginAsync(loginDto);
        return HandleResponse(response);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var response = await authService.LogoutAsync();
        return HandleResponse(response);
    }
}
