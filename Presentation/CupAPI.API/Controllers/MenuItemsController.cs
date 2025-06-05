using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Features.Menu.Commands.CreateMenu;
using CupAPI.Application.Features.Menu.Commands.DeleteMenu;
using CupAPI.Application.Features.Menu.Commands.UpdateMenu;
using CupAPI.Application.Features.Menu.Queries.GetAllMenus;
using CupAPI.Application.Features.Menu.Queries.GetMenuById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthorizationPolicy = CupAPI.Domain.Enums.AuthorizationPolicy;

namespace CupAPI.API.Controllers;

public class MenuItemsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllMenusQuery());
        return HandleResponse(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetMenuByIdQuery(id));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMenuItemDto createMenuItemDto)
    {
        var response = await Mediator.Send(new CreateMenuCommand(createMenuItemDto));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMenuItemDto updateMenuItemDto)
    {
        var response = await Mediator.Send(new UpdateMenuCommand(updateMenuItemDto));
        return HandleResponse(response);
    }

    [Authorize(Policy = AuthorizationPolicy.AdminOnly)]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await Mediator.Send(new DeleteMenuCommand(id));
        return HandleResponse(response);
    }
}