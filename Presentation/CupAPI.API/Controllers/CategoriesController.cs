using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CupAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        List<ResultCategoryDto> resultCategoryDtos  = await categoryService.GetAllCategories();
        return Ok(resultCategoryDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdCategory(int id)
    {
        DetailCategoryDto detailCategoryDto = await categoryService.GetByIdCategory(id);
        return Ok(detailCategoryDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDto createCategoryDto)
    {
        await categoryService.AddCategory(createCategoryDto);
        return Ok("Kategori Oluşturuldu");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
    {
        await categoryService.UpdateCategory(updateCategoryDto);
        return Ok("Kategori Güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await categoryService.DeleteCategory(id);
        return Ok("Kategori silindi");
    }
}