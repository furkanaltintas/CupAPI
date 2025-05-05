using AutoMapper;
using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Common.Helpers;
using CupAPI.Application.Common.Responses;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;
using FluentValidation;

namespace CupAPI.Application.Services.Concrete;

public class MenuItemService(
    IGenericRepository<Category> categoryRepository,
    IGenericRepository<MenuItem> menuItemRepository,
    IMapper mapper,
    IValidator<CreateMenuItemDto> createMenuItemValidator,
    IValidator<UpdateMenuItemDto> updateMenuItemValidator) : IMenuItemService
{
    public async Task<ApiResponse<object>> AddAsync(CreateMenuItemDto createMenuItemDto)
    {
        try
        {
            var response = await ValidationHelper.ValidateAsync(createMenuItemValidator, createMenuItemDto);
            if (!response.Success) return response;

            MenuItem menuItem = mapper.Map<MenuItem>(createMenuItemDto);
            await menuItemRepository.AddAsync(menuItem);

            return ApiResponse<object>.SuccessNoDataResult(Messages.MenuItem.Created);
        }
        catch
        {
            return ApiResponse<object>.Fail(Messages.MenuItem.ErrorWhileAdding, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<object>> DeleteAsync(int id)
    {
        try
        {
            MenuItem menuItem = await menuItemRepository.GetByIdAsync(id);
            if (menuItem is null) return ApiResponse<object>.Fail(Messages.MenuItem.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            await menuItemRepository.DeleteAsync(menuItem);
            return ApiResponse<object>.SuccessNoDataResult(Messages.MenuItem.Deleted);
        }
        catch
        {
            return ApiResponse<object>.Fail(Messages.MenuItem.ErrorWhileDeleting, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultMenuItemDto>>> GetAllAsync()
    {
        try
        {
            List<Category> categories = await categoryRepository.GetAllAsync();
            List<MenuItem> menuItems = await menuItemRepository.GetAllAsync();

            if (menuItems is null || !menuItems.Any()) return ApiResponse<List<ResultMenuItemDto>>.Fail(Messages.MenuItem.ErrorWhileFetching, ErrorCodeEnum.NotFound);

            List<ResultMenuItemDto> dtos = mapper.Map<List<ResultMenuItemDto>>(menuItems);
            return ApiResponse<List<ResultMenuItemDto>>.SuccessResult(dtos);
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
            MenuItem menuItem = await menuItemRepository.GetByIdAsync(id);
            if (menuItem is null) return ApiResponse<DetailMenuItemDto>.Fail(Messages.MenuItem.NotFound, ErrorCodeEnum.NotFound);

            DetailMenuItemDto detailMenuItemDto = mapper.Map<DetailMenuItemDto>(menuItem);
            return ApiResponse<DetailMenuItemDto>.SuccessResult(detailMenuItemDto);
        }
        catch
        {
            return ApiResponse<DetailMenuItemDto>.Fail(Messages.MenuItem.ErrorWhileFetching, ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<object>> UpdateAsync(UpdateMenuItemDto updateMenuItemDto)
    {
        try
        {
            var response = await ValidationHelper.ValidateAsync(updateMenuItemValidator, updateMenuItemDto);
            if (!response.Success) return response;

            MenuItem menuItem = await menuItemRepository.GetByIdAsync(updateMenuItemDto.Id);
            if (menuItem is null) return ApiResponse<object>.Fail(Messages.MenuItem.NotFound, ErrorCodeEnum.NotFound);

            mapper.Map(updateMenuItemDto, menuItem);
            await menuItemRepository.UpdateAsync(menuItem);

            return ApiResponse<object>.SuccessNoDataResult(Messages.MenuItem.Updated);
        }
        catch
        {
            return ApiResponse<object>.Fail(Messages.MenuItem.ErrorWhileUpdating, ErrorCodeEnum.Exception);
        }
    }
}
