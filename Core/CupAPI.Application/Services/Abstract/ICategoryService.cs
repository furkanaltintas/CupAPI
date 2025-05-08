using CupAPI.Application.Dtos.CategoryDtos;

namespace CupAPI.Application.Services.Abstract;

public interface ICategoryService
{
    Task<ApiResponse<List<ResultCategoryDto>>> GetAllAsync();
    Task<ApiResponse<DetailCategoryDto>> GetByIdAsync(int id);
    Task<ApiResponse<String>> AddAsync(CreateCategoryDto createCategoryDto);
    Task<ApiResponse<String>> UpdateAsync(UpdateCategoryDto updateCategoryDto);
    Task<ApiResponse<String>> DeleteAsync(int id);
}