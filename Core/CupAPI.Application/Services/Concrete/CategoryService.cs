using CupAPI.Application.Services.Abstract;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Common.Responses;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Helpers;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using FluentValidation;
using AutoMapper;

namespace CupAPI.Application.Services.Concrete;

public class CategoryService(
    IGenericRepository<Category> categoryRepository,
    IMapper mapper,
    IValidator<CreateCategoryDto> createCategoryValidator,
    IValidator<UpdateCategoryDto> updateCategoryValidator
    ) : ICategoryService
{
    public async Task<ApiResponse<object>> AddAsync(CreateCategoryDto createCategoryDto)
    {
        try
        {
            var response = await ValidationHelper.ValidateAsync(createCategoryValidator, createCategoryDto);
            if (!response.Success) return response;

            Category category = mapper.Map<Category>(createCategoryDto);
            await categoryRepository.AddAsync(category);
            return ApiResponse<object>.SuccessNoDataResult(Messages.Category.Created);
        }
        catch
        {
            return ApiResponse<object>.Fail(Messages.Category.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<object>> DeleteAsync(int id)
    {
        try
        {
            Category category = await categoryRepository.GetByIdAsync(id);

            if (category is null) return ApiResponse<object>.Fail(Messages.Category.NotFound, ErrorCodeEnum.NotFound);

            await categoryRepository.DeleteAsync(category);
            return ApiResponse<object>.SuccessNoDataResult(Messages.Category.Deleted);
        }
        catch
        {
            return ApiResponse<object>.Fail(Messages.Category.ErrorWhileDeleting, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultCategoryDto>>> GetAllAsync()
    {
        try
        {
            List<Category> categories = await categoryRepository.GetAllAsync();

            if (categories is null || !categories.Any()) return ApiResponse<List<ResultCategoryDto>>.Fail(Messages.Category.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            List<ResultCategoryDto> dtos = mapper.Map<List<ResultCategoryDto>>(categories);
            return ApiResponse<List<ResultCategoryDto>>.SuccessResult(dtos);
        }
        catch
        {
            return ApiResponse<List<ResultCategoryDto>>.Fail(Messages.Category.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailCategoryDto>> GetByIdAsync(int id)
    {
        try
        {
            Category? category = await categoryRepository.GetByIdAsync(id);
            if (category is null) return ApiResponse<DetailCategoryDto>.Fail(Messages.Category.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            DetailCategoryDto detailCategoryDto = mapper.Map<DetailCategoryDto>(category);
            return ApiResponse<DetailCategoryDto>.SuccessResult(detailCategoryDto);
        }
        catch
        {
            return ApiResponse<DetailCategoryDto>.Fail(Messages.Category.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<object>> UpdateAsync(UpdateCategoryDto updateCategoryDto)
    {
        try
        {
            var response = await ValidationHelper.ValidateAsync(updateCategoryValidator, updateCategoryDto);
            if (!response.Success) return response;

            Category category = await categoryRepository.GetByIdAsync(updateCategoryDto.Id);
            if (category is null) return ApiResponse<object>.Fail(Messages.Category.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            mapper.Map(updateCategoryDto, category);
            await categoryRepository.UpdateAsync(category);

            return ApiResponse<object>.SuccessNoDataResult(Messages.Category.Updated);
        }
        catch
        {
            return ApiResponse<object>.Fail(Messages.Category.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}