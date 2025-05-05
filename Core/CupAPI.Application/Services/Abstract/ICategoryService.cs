using CupAPI.Application.Common.Responses;
using CupAPI.Application.Dtos.CategoryDtos;

namespace CupAPI.Application.Services.Abstract;

public interface ICategoryService
{
    Task<ApiResponse<List<ResultCategoryDto>>> GetAllAsync();
    Task<ApiResponse<DetailCategoryDto>> GetByIdAsync(int id);
    Task<ApiResponse<object>> AddAsync(CreateCategoryDto createCategoryDto);
    Task<ApiResponse<object>> UpdateAsync(UpdateCategoryDto updateCategoryDto);
    Task<ApiResponse<object>> DeleteAsync(int id);
}