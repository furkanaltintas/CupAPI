using CupAPI.Application.Dtos.CategoryDtos;

namespace CupAPI.Application.Services.Abstract;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategories();
    Task<DetailCategoryDto> GetByIdCategory(int id);
    Task AddCategory(CreateCategoryDto createCategoryDto);
    Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategory(int id);
}