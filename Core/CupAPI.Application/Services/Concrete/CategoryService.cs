using AutoMapper;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Dtos.ResponseDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Services.Concrete;

public class CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper) : ICategoryService
{
    public async Task AddCategory(CreateCategoryDto createCategoryDto)
    {
        Category category = mapper.Map<Category>(createCategoryDto);
        await categoryRepository.AddAsync(category);
    }

    public async Task DeleteCategory(int id)
    {
        Category category = await categoryRepository.GetByIdAsync(id);
        await categoryRepository.DeleteAsync(category);
    }

    public async Task<ResponseDto<List<ResultCategoryDto>>> GetAllCategories()
    {
        try
        {
            List<Category> categories = await categoryRepository.GetAllAsync();

            if (categories == null || !categories.Any())
                return ResponseDto<List<ResultCategoryDto>>.Fail("Kategori Bulunamadı", ErrorCode.NotFound);

            var dtos = mapper.Map<List<ResultCategoryDto>>(categories);
            return ResponseDto<List<ResultCategoryDto>>.SuccessResult(dtos);
        }
        catch (Exception ex)
        {
            return ResponseDto<List<ResultCategoryDto>>.Fail("Kategori getirilirken bir hata oluştu.", ErrorCode.Exception);
        }
    }

    public async Task<ResponseDto<DetailCategoryDto>> GetByIdCategory(int id)
    {
        try
        {
            Category? category = await categoryRepository.GetByIdAsync(id);
            if (category is null)
                return ResponseDto<DetailCategoryDto>.Fail("Kategori Bulunamadı", ErrorCode.NotFound);

            var detailCategoryDto = mapper.Map<DetailCategoryDto>(category);

            return ResponseDto<DetailCategoryDto>.SuccessResult(detailCategoryDto);
        }
        catch (Exception ex)
        {
            return ResponseDto<DetailCategoryDto>.Fail("Kategori getirilirken bir hata oluştu", ErrorCode.Exception);
        }
    }

    public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        Category category = mapper.Map<Category>(updateCategoryDto);
        await categoryRepository.UpdateAsync(category);
    }
}
