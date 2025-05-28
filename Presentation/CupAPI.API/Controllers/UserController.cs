using CupAPI.API.Controllers.Common;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

[AllowAnonymous]
public class UserController(IUserService userService) : BaseApiController
{
    [HttpPost("createRole")]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        var result = await userService.CreateRole(roleName);
        return HandleResponse(result);
    }

    [HttpPost("addRoleToUser")]
    public async Task<IActionResult> AddRoleToUser(string email, string roleName)
    {
        var result = await userService.AddRoleToUser(email, roleName);
        return HandleResponse(result);
    }
}