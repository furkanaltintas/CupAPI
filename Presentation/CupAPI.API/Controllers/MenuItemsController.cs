using CupAPI.API.Controllers.Common;
using CupAPI.Application.Common.Responses;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuItemsController(IMenuItemService menuItemService) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllMenuItems()
    {
        ApiResponse<List<ResultMenuItemDto>> resultMenuItemDtos = await menuItemService.GetAllMenuItems();
        return Ok(resultMenuItemDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdMenuItem(int id)
    {
        var response = await menuItemService.GetByIdMenuItem(id);
        return HandleResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddMenuItem(CreateMenuItemDto createMenuItemDto)
    {
        var response =  await menuItemService.AddMenuItem(createMenuItemDto);
        return HandleResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMenuItem(UpdateMenuItemDto updateMenuItemDto)
    {
        var response = await menuItemService.UpdateMenuItem(updateMenuItemDto);
        return HandleResponse(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMenuItem(int id)
    {
        var response = await menuItemService.DeleteMenuItem(id);
        return HandleResponse(response);
    }
}