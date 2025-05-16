using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Common.Helpers;
using CupAPI.Application.Common.Rules.MenuItemRules;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CupAPI.Application.Services.Concrete;

public class MenuItemService(
    IMenuItemRepository menuItemRepository,
    IMapper mapper,
    IValidationHelper validationHelper,
    MenuItemBusinessRules menuItemBusinessRules) : IMenuItemService
{
    public async Task<ApiResponse<String>> AddAsync(CreateMenuItemDto createMenuItemDto)
    {
        try
        {
            var response = await validationHelper.ValidateAsync<CreateMenuItemDto, String>(createMenuItemDto);
            if (!response.Success) return response;

            var menuItem = mapper.Map<MenuItem>(createMenuItemDto);
            await menuItemRepository.AddAsync(menuItem);
            await menuItemRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.MenuItem.Created);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.MenuItem.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> DeleteAsync(int id)
    {
        try
        {
            var response = await menuItemBusinessRules.MenuItemShouldExist(id);
            if (!response.Success) return ApiResponse<String>.Fail(response.Message, response.ErrorCode);

            menuItemRepository.Delete(response.Data!);
            await menuItemRepository.SaveChangesAsync();
            return ApiResponse<String>.SuccessNoDataResult(Messages.MenuItem.Deleted);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.MenuItem.ErrorWhileDeleting, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultMenuItemDto>>> GetAllAsync()
    {
        try
        {
            var menuItems = await menuItemRepository.GetAllAsync(include: m => m.Include(m => m.Category));
            if (menuItems is null || !menuItems.Any()) return ApiResponse<List<ResultMenuItemDto>>.SuccessEmptyDataResult(new(), Messages.General.DataIsEmpty, ErrorCodeEnum.EmptyData);

            var resultMenuItemDtos = mapper.Map<List<ResultMenuItemDto>>(menuItems);
            return ApiResponse<List<ResultMenuItemDto>>.SuccessResult(resultMenuItemDtos);
        }
        catch
        {
            return ApiResponse<List<ResultMenuItemDto>>.Fail(Messages.MenuItem.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailMenuItemDto>> GetByIdAsync(int id)
    {
        try
        {
            var response = await menuItemBusinessRules.MenuItemShouldExist(id);
            if (!response.Success) return ApiResponse<DetailMenuItemDto>.Fail(response.Message, response.ErrorCode);

            var detailMenuItemDto = mapper.Map<DetailMenuItemDto>(response.Data!);
            return ApiResponse<DetailMenuItemDto>.SuccessResult(detailMenuItemDto);
        }
        catch
        {
            return ApiResponse<DetailMenuItemDto>.Fail(Messages.MenuItem.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<String>> UpdateAsync(UpdateMenuItemDto updateMenuItemDto)
    {
        try
        {
            var validateResponse = await validationHelper.ValidateAsync<UpdateMenuItemDto, String>(updateMenuItemDto);
            if (!validateResponse.Success) return validateResponse;

            var businessResponse = await menuItemBusinessRules.MenuItemShouldExist(updateMenuItemDto.Id);
            if (!businessResponse.Success) return ApiResponse<String>.Fail(businessResponse.Message, businessResponse.ErrorCode);

            if (businessResponse.Data is null) return ApiResponse<String>.Fail(Messages.MenuItem.NotFound, ErrorCodeEnum.NotFound);

            mapper.Map(updateMenuItemDto, businessResponse.Data);
            menuItemRepository.Update(businessResponse.Data);
            await menuItemRepository.SaveChangesAsync();

            return ApiResponse<String>.SuccessNoDataResult(Messages.MenuItem.Updated);
        }
        catch
        {
            return ApiResponse<String>.Fail(Messages.MenuItem.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}