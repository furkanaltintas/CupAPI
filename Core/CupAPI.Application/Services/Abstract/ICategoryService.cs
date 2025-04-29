using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Dtos.ResponseDtos;

namespace CupAPI.Application.Services.Abstract;

public interface ICategoryService
{
    Task<ResponseDto<List<ResultCategoryDto>>> GetAllCategories();
    Task<ResponseDto<DetailCategoryDto>> GetByIdCategory(int id);
    Task AddCategory(CreateCategoryDto createCategoryDto);
    Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategory(int id);
}