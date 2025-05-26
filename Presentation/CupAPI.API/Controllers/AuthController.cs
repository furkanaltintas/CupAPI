using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

[AllowAnonymous]
public sealed class AuthController(IAuthService authService) : BaseApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        TokenResponseDto token = await authService.RegisterAsync(dto);
        return Ok(token);
    }

    [HttpPost("login")]

    public async Task<IActionResult> Login(LoginDto dto)
    {
        TokenResponseDto token = await authService.LoginAsync(dto);
        return Ok(token);
    }
}
