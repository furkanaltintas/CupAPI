using CupAPI.API.Controllers.Common;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

public class CategoriesController(ICategoryService categoryService) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var response = await categoryService.GetAllCategories();
        return HandleResponse(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdCategory(int id)
    {
        var response = await categoryService.GetByIdCategory(id);
        return HandleResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDto createCategoryDto)
    {
        var response = await categoryService.AddCategory(createCategoryDto);
        return HandleResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
    {
        var response = await categoryService.UpdateCategory(updateCategoryDto);
        return HandleResponse(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var response = await categoryService.DeleteCategory(id);
        return HandleResponse(response);
    }
}