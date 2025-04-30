using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Dtos.ResponseDtos;

namespace CupAPI.Application.Services.Abstract;

public interface ICategoryService
{
    Task<ResponseDto<List<ResultCategoryDto>>> GetAllCategories();
    Task<ResponseDto<DetailCategoryDto>> GetByIdCategory(int id);
    Task<ResponseDto<object>> AddCategory(CreateCategoryDto createCategoryDto);
    Task<ResponseDto<object>> UpdateCategory(UpdateCategoryDto updateCategoryDto);
    Task<ResponseDto<object>> DeleteCategory(int id);
}