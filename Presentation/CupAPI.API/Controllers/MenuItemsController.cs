using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuItemsController(IMenuItemService menuItemService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllMenuItems()
    {
        List<ResultMenuItemDto> resultMenuItemDtos = await menuItemService.GetAllMenuItems();
        return Ok(resultMenuItemDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdMenuItem(int id)
    {
        DetailMenuItemDto detailMenuItemDto = await menuItemService.GetByIdMenuItem(id);
        return Ok(detailMenuItemDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddMenuItem(CreateMenuItemDto createMenuItemDto)
    {
        await menuItemService.AddMenuItem(createMenuItemDto);
        return Ok("Menu Item eklendi");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMenuItem(UpdateMenuItemDto updateMenuItemDto)
    {
        await menuItemService.UpdateMenuItem(updateMenuItemDto);
        return Ok("Menu Item güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMenuItem(int id)
    {
        await menuItemService.DeleteMenuItem(id);
        return Ok("Menu Item silindi");
    }
}