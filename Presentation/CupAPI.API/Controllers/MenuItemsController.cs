using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

public class MenuItemsController(IMenuItemService menuItemService) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await menuItemService.GetAllAsync();
        return HandleResponse(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await menuItemService.GetByIdAsync(id);
        return HandleResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMenuItemDto createMenuItemDto)
    {
        var response =  await menuItemService.AddAsync(createMenuItemDto);
        return HandleResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMenuItemDto updateMenuItemDto)
    {
        var response = await menuItemService.UpdateAsync(updateMenuItemDto);
        return HandleResponse(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await menuItemService.DeleteAsync(id);
        return HandleResponse(response);
    }
}