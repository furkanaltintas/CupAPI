using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

[AllowAnonymous]
public class UserController(IUserService userService) : BaseApiController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var response = await userService.LoginAsync(loginDto);
        return HandleResponse(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await userService.RegisterAsync(registerDto);
        return HandleResponse(result);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var response = await userService.LogoutAsync();
        return HandleResponse(response);
    }
}
