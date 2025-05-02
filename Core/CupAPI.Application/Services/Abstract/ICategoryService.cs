using CupAPI.Application.Common.Responses;
using CupAPI.Application.Dtos.CategoryDtos;

namespace CupAPI.Application.Services.Abstract;

public interface ICategoryService
{
    Task<ApiResponse<List<ResultCategoryDto>>> GetAllCategories();
    Task<ApiResponse<DetailCategoryDto>> GetByIdCategory(int id);
    Task<ApiResponse<object>> AddCategory(CreateCategoryDto createCategoryDto);
    Task<ApiResponse<object>> UpdateCategory(UpdateCategoryDto updateCategoryDto);
    Task<ApiResponse<object>> DeleteCategory(int id);
}