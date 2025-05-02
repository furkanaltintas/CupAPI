using AutoMapper;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Common.Responses;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;
using FluentValidation;
using CupAPI.Application.Common.Helpers;
using CupAPI.Application.Common.Enums;

namespace CupAPI.Application.Services.Concrete;

public class CategoryService(
    IGenericRepository<Category> categoryRepository,
    IMapper mapper,
    IValidator<CreateCategoryDto> createCategoryValidator,
    IValidator<UpdateCategoryDto> updateCategoryValidator
    ) : ICategoryService
{
    public async Task<ApiResponse<object>> AddCategory(CreateCategoryDto createCategoryDto)
    {
        try
        {
            var response = await ValidationHelper.ValidateAsync(createCategoryValidator, createCategoryDto);
            if (!response.Success) return response;

            Category category = mapper.Map<Category>(createCategoryDto);
            await categoryRepository.AddAsync(category);

            return ApiResponse<object>.SuccessNoDataResult("Kategori oluşturuldu");

        }
        catch (Exception)
        {
            return ApiResponse<object>.Fail("Kategori eklenirken bir hata oluştu", ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<object>> DeleteCategory(int id)
    {
        try
        {
            Category category = await categoryRepository.GetByIdAsync(id);

            if (category is null) return ApiResponse<object>.Fail("Kategori Bulunamadı", ErrorCodeEnum.NotFound);

            await categoryRepository.DeleteAsync(category);
            return ApiResponse<object>.SuccessNoDataResult("Kategori Silindi");
        }
        catch (Exception)
        {
            return ApiResponse<object>.Fail("Kategori getirilirken bir hata oluştu", ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultCategoryDto>>> GetAllCategories()
    {
        try
        {
            List<Category> categories = await categoryRepository.GetAllAsync();

            if (categories is null || !categories.Any()) return ApiResponse<List<ResultCategoryDto>>.Fail("Kategori Bulunamadı", ErrorCodeEnum.NotFound);

            List<ResultCategoryDto> dtos = mapper.Map<List<ResultCategoryDto>>(categories);
            return ApiResponse<List<ResultCategoryDto>>.SuccessResult(dtos);
        }
        catch (Exception)
        {
            return ApiResponse<List<ResultCategoryDto>>.Fail("Kategori getirilirken bir hata oluştu", ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailCategoryDto>> GetByIdCategory(int id)
    {
        try
        {
            Category? category = await categoryRepository.GetByIdAsync(id);
            if (category is null) return ApiResponse<DetailCategoryDto>.Fail("Kategori Bulunamadı", ErrorCodeEnum.NotFound);

            DetailCategoryDto detailCategoryDto = mapper.Map<DetailCategoryDto>(category);
            return ApiResponse<DetailCategoryDto>.SuccessResult(detailCategoryDto);
        }
        catch (Exception)
        {
            return ApiResponse<DetailCategoryDto>.Fail("Kategori getirilirken bir hata oluştu", ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<object>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        try
        {
            var response = await ValidationHelper.ValidateAsync(updateCategoryValidator, updateCategoryDto);
            if (!response.Success) return response;

            Category category = await categoryRepository.GetByIdAsync(updateCategoryDto.Id);
            if (category is null) return ApiResponse<object>.Fail("Kategori Bulunamadı", ErrorCodeEnum.NotFound);

            mapper.Map(updateCategoryDto, category);
            await categoryRepository.UpdateAsync(category);

            return ApiResponse<object>.SuccessNoDataResult("Kategori güncellendi");
        }
        catch (Exception)
        {
            return ApiResponse<object>.Fail("Kategori güncellenirken bir hata oluştu", ErrorCodeEnum.Exception);
        }
    }
}