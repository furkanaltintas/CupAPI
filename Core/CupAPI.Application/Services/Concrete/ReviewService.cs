using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Common.Helpers.Validation.Abstract;
using CupAPI.Application.Common.Helpers.Validation.Concrete;
using CupAPI.Application.Common.Rules.CategoryRules;
using CupAPI.Application.Common.Rules.ReviewRules;
using CupAPI.Application.Common.Rules.TableRules;
using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Dtos.ReviewDtos;
using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Services.Concrete;

public sealed class ReviewService(
    IReviewRepository reviewRepository,
    ReviewBusinessRules reviewBusinessRules,
    IMapper mapper,
    IValidationHelper validationHelper) : IReviewService
{
    public async Task<ApiResponse<string>> AddAsync(CreateReviewDto createReviewDto)
    {
        try
        {
            var response = await validationHelper.ValidateAsync<CreateReviewDto, String>(createReviewDto);
            if (!response.Success) return response;

            var review = mapper.Map<Review>(createReviewDto);
            await reviewRepository.AddAsync(review);
            await reviewRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Review.Created);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Review.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<string>> DeleteAsync(int id)
    {
        try
        {
            var response = await reviewBusinessRules.ReviewShouldExist(id);
            if (!response.Success) return ApiResponse<String>.Fail(response.Message, response.ErrorCode);

            reviewRepository.Delete(response.Data!);
            await reviewRepository.SaveChangesAsync();
            return ApiResponse<String>.SuccessNoDataResult(Messages.Category.Deleted);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Category.ErrorWhileDeleting, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultReviewDto>>> GetAllAsync()
    {
        try
        {
            var categories = await reviewRepository.GetAllAsync();
            if (categories is null || !categories.Any()) return ApiResponse<List<ResultReviewDto>>.SuccessEmptyDataResult(new(), Messages.General.DataIsEmpty, ErrorCodeEnum.EmptyData);

            var resultReviewDtos = mapper.Map<List<ResultReviewDto>>(categories);
            return ApiResponse<List<ResultReviewDto>>.SuccessResult(resultReviewDtos);
        }
        catch
        {
            return ApiResponse<List<ResultReviewDto>>.Fail(Messages.Review.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailReviewDto>> GetByIdAsync(int id)
    {
        try
        {
            var response = await reviewBusinessRules.ReviewShouldExist(id);
            if (!response.Success) return ApiResponse<DetailReviewDto>.Fail(response.Message, response.ErrorCode);

            var detailReviewDto = mapper.Map<DetailReviewDto>(response.Data!);
            return ApiResponse<DetailReviewDto>.SuccessResult(detailReviewDto);
        }
        catch
        {
            return ApiResponse<DetailReviewDto>.Fail(Messages.Review.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<string>> UpdateAsync(UpdateReviewDto updateReviewDto)
    {
        try
        {
            var validateResponse = await validationHelper.ValidateAsync<UpdateReviewDto, String>(updateReviewDto);
            if (!validateResponse.Success) return validateResponse;

            var businessResponse = await reviewBusinessRules.ReviewShouldExist(updateReviewDto.Id);
            if (!businessResponse.Success) return ApiResponse<String>.Fail(businessResponse.Message, businessResponse.ErrorCode);

            if (businessResponse.Data is null) return ApiResponse<String>.Fail(Messages.MenuItem.NotFound, ErrorCodeEnum.NotFound);

            mapper.Map(updateReviewDto, businessResponse.Data!);
            reviewRepository.Update(businessResponse.Data!);
            await reviewRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.Table.Updated);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.Table.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}
