using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.AuthDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

[AllowAnonymous] // Bu controller, authentication gerektirmez
public sealed class AuthController(IAuthService authService) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> GenerateToken(TokenDto tokenDto)
    {
        var response = await authService.GenerateToken(tokenDto);
        return HandleResponse(response);
    }
}
