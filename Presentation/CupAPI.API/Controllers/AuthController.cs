using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Features.Auth.Commands.Login;
using CupAPI.Application.Features.Auth.Commands.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

[AllowAnonymous]
public sealed class AuthController : BaseApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        TokenResponseDto token = await Mediator.Send(new RegisterCommand(registerDto));
        return Ok(token);
    }

    [HttpPost("login")]

    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        TokenResponseDto token = await Mediator.Send(new LoginCommand(loginDto));
        return Ok(token);
    }
}