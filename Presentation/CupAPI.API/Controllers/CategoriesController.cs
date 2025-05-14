using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

public class CategoriesController(ICategoryService categoryService) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await categoryService.GetAllAsync();
        return HandleResponse(response);
    }

    [HttpGet("getAllCategoriesWithMenuItems")]
    public async Task<IActionResult> GetAllCategoriesWithMenuItems()
    {
        var response = await categoryService.GetCategoriesWithMenuItemAsync();
        return HandleResponse(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var response = await categoryService.GetByIdAsync(id);
        return HandleResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCategoryDto createCategoryDto)
    {
        var response = await categoryService.AddAsync(createCategoryDto);
        return HandleResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryDto updateCategoryDto)
    {
        var response = await categoryService.UpdateAsync(updateCategoryDto);
        return HandleResponse(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await categoryService.DeleteAsync(id);
        return HandleResponse(response);
    }
}