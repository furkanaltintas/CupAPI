using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Common.Helpers;
using CupAPI.Application.Common.Rules.CategoryRules;
using CupAPI.Application.Common.Services;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Services.Concrete;

public class CategoryService(
    IGenericRepository<Category> categoryRepository,
    IMapper mapper,
    CategoryBusinessRules categoryBusinessRules,
    UpdateService updateService,
    CreateService createService
    ) : ICategoryService
{
    public async Task<ApiResponse<String>> AddAsync(CreateCategoryDto createCategoryDto)
    {
        return await createService.HandleAsync<CreateCategoryDto, Category, String>(
            dto: createCategoryDto,
            addEntity: async entity => await categoryRepository.AddAsync(entity),
            saveEntity: async entity => await categoryRepository.SaveChangesAsync(),
            successMessage: Messages.Category.Created);
    }

    public async Task<ApiResponse<String>> DeleteAsync(int id)
    {
        try
        {
            var response = await categoryBusinessRules.CategoryShouldExist(id);
            if (!response.Success) return ApiResponse<String>.Fail(response.Message, response.ErrorCode);

            categoryRepository.Delete(response.Data!);
            await categoryRepository.SaveChangesAsync();
            return ApiResponse<String>.SuccessNoDataResult(Messages.Category.Deleted);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Category.ErrorWhileDeleting, ErrorCodeEnum.Exception);
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
            var response = await categoryBusinessRules.CategoryShouldExist(id);
            if (!response.Success) return ApiResponse<DetailCategoryDto>.Fail(response.Message, response.ErrorCode);

            DetailCategoryDto detailCategoryDto = mapper.Map<DetailCategoryDto>(response.Data!);
            return ApiResponse<DetailCategoryDto>.SuccessResult(detailCategoryDto);
        }
        catch
        {
            return ApiResponse<DetailCategoryDto>.Fail(Messages.Category.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> UpdateAsync(UpdateCategoryDto updateCategoryDto)
    {
        return await updateService.HandleAsync<UpdateCategoryDto, Category, String>(
            dto: updateCategoryDto,
            idSelector: u => u.Id,
            fetchEntity: async id => await categoryRepository.GetByIdAsync(id),
            updateEntity: entity => categoryRepository.Update(entity),
            saveEntity: async entity => await categoryRepository.SaveChangesAsync(),
            successMessage: Messages.Category.Updated);
    }
}












// CATEGORY

//try
//{
//    var response = await validationHelper.ValidateAsync<CreateCategoryDto, String>(createCategoryDto);
//    if (!response.Success) return response;

//    Category category = mapper.Map<Category>(createCategoryDto);
//    await categoryRepository.AddAsync(category);
//    return ApiResponse<String>.SuccessNoDataResult(Messages.Category.Created);
//}
//catch
//{
//    return ApiResponse<String>.Fail(Messages.Category.ErrorWhileAdding, ErrorCodeEnum.Exception);
//}













// UPDATE

//try
//{
//    var validateResponse = await validationHelper.ValidateAsync<UpdateCategoryDto, String>(updateCategoryDto);
//    if (!validateResponse.Success) return validateResponse;

//    var businessResponse = await categoryBusinessRules.CategoryShouldExist(updateCategoryDto.Id);
//    if(!businessResponse.Success) return ApiResponse<String>.Fail(businessResponse.Message, businessResponse.ErrorCode);

//    if (businessResponse.Data is null) return ApiResponse<String>.Fail(Messages.MenuItem.NotFound, ErrorCodeEnum.NotFound);

//    mapper.Map(updateCategoryDto, businessResponse.Data);
//    await categoryRepository.UpdateAsync(businessResponse.Data);

//    return ApiResponse<String>.SuccessNoDataResult(Messages.Category.Updated);
//}
//catch
//{
//    return ApiResponse<String>.Fail(Messages.Category.ErrorWhileUpdating, ErrorCodeEnum.Exception);
//}