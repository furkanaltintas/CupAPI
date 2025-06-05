using CupAPI.API.Controllers.Common;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using AuthorizationPolicy = CupAPI.Domain.Enums.AuthorizationPolicy;

namespace CupAPI.API.Controllers;

[Authorize(Policy = AuthorizationPolicy.AdminOnly)]
public class UserController(IUserService userService) : BaseApiController
{
    //[HttpPost("createrole")]
    //public async Task<IActionResult> CreateRole(string roleName)
    //{
    //    var result = await userService.CreateRole(roleName);
    //    return HandleResponse(result);
    //}

    //[HttpPost("addrole")]
    //public async Task<IActionResult> AddRoleToUser(string email, string roleName)
    //{
    //    var result = await userService.AddRoleToUser(email, roleName);
    //    return HandleResponse(result);
    //}
}