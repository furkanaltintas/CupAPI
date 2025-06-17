using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Common.Helpers.Validation.Abstract;
using CupAPI.Application.Dtos.CafeInfoDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Services.Concrete;

public class CafeInfoService(
    ICafeInfoRepository cafeInfoRepository,
    IMapper mapper,
    IValidationHelper validationHelper) : ICafeInfoService
{
    public async Task<ApiResponse<string>> AddAsync(CreateCafeInfoDto createCafeInfoDto)
    {
        try
        {
            var response = await validationHelper.ValidateAsync<CreateCafeInfoDto, String>(createCafeInfoDto);
            if (!response.Success) return response;

            CafeInfo cafeInfo = mapper.Map<CafeInfo>(createCafeInfoDto);
            await cafeInfoRepository.AddAsync(cafeInfo);
            await cafeInfoRepository.SaveChangesAsync();
            return ApiResponse<String>.SuccessNoDataResult(Messages.CafeInfo.Created);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.CafeInfo.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<string>> DeleteAsync(int id)
    {
        try
        {
            var cafeInfo = await cafeInfoRepository.GetByIdAsync(id);
            if (cafeInfo is null) return ApiResponse<String>.Fail(Messages.CafeInfo.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            cafeInfoRepository.Delete(cafeInfo);
            await cafeInfoRepository.SaveChangesAsync();
            return ApiResponse<String>.SuccessNoDataResult(Messages.CafeInfo.Deleted);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.CafeInfo.ErrorWhileDeleting, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultCafeInfoDto>>> GetAllAsync()
    {
        try
        {
            var cafeInfos = await cafeInfoRepository.GetAllAsync();
            if (cafeInfos is null || !cafeInfos.Any()) return ApiResponse<List<ResultCafeInfoDto>>.SuccessEmptyDataResult(new(), Messages.General.DataIsEmpty, ErrorCodeEnum.EmptyData);

            var resultCafeInfoDtos = mapper.Map<List<ResultCafeInfoDto>>(cafeInfos);
            return ApiResponse<List<ResultCafeInfoDto>>.SuccessResult(resultCafeInfoDtos);
        }
        catch
        {
            return ApiResponse<List<ResultCafeInfoDto>>.Fail(Messages.CafeInfo.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailCafeInfoDto>> GetByIdAsync(int id)
    {
        try
        {
            var cafeInfo = await cafeInfoRepository.GetByIdAsync(id);
            if (cafeInfo is null) return ApiResponse<DetailCafeInfoDto>.Fail(Messages.CafeInfo.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            DetailCafeInfoDto detailCafeInfoDto = mapper.Map<DetailCafeInfoDto>(cafeInfo);
            return ApiResponse<DetailCafeInfoDto>.SuccessResult(detailCafeInfoDto);
        }
        catch
        {
            return ApiResponse<DetailCafeInfoDto>.Fail(Messages.CafeInfo.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<string>> UpdateAsync(UpdateCafeInfoDto updateCafeInfoDto)
    {
        try
        {
            var validateResponse = await validationHelper.ValidateAsync<UpdateCafeInfoDto, String>(updateCafeInfoDto);
            if (!validateResponse.Success) return validateResponse;

            var cafeInfo = await cafeInfoRepository.GetByIdAsync(updateCafeInfoDto.Id);
            if (cafeInfo is null) return ApiResponse<String>.Fail(Messages.CafeInfo.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            mapper.Map(updateCafeInfoDto, cafeInfo);
            cafeInfoRepository.Update(cafeInfo);
            await cafeInfoRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.CafeInfo.Updated);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.CafeInfo.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}