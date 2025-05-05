using AutoMapper;
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
    public async Task<ApiResponse<object>> AddMenuItem(CreateMenuItemDto createMenuItemDto)
    {
        try
        {
            var response = await ValidationHelper.ValidateAsync(createMenuItemValidator, createMenuItemDto);
            if (!response.Success) return response;

            MenuItem menuItem = mapper.Map<MenuItem>(createMenuItemDto);
            await menuItemRepository.AddAsync(menuItem);

            return ApiResponse<object>.SuccessNoDataResult("Menü oluşturuldu");
        }
        catch (Exception)
        {
            return ApiResponse<object>.Fail("Menü eklenirken bir hata oluştu", ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<object>> DeleteMenuItem(int id)
    {
        try
        {
            MenuItem menuItem = await menuItemRepository.GetByIdAsync(id);
            if (menuItem is null) return ApiResponse<object>.Fail("Menü Bulunamadı", ErrorCodeEnum.NotFound);

            await menuItemRepository.DeleteAsync(menuItem);
            return ApiResponse<object>.SuccessNoDataResult("Menü silindi");
        }
        catch (Exception)
        {
            return ApiResponse<object>.Fail("Menü silinirken bir hata oluştu", ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<List<ResultMenuItemDto>>> GetAllMenuItems()
    {
        try
        {
            List<Category> categories = await categoryRepository.GetAllAsync();
            List<MenuItem> menuItems = await menuItemRepository.GetAllAsync();

            if (menuItems is null || !menuItems.Any()) return ApiResponse<List<ResultMenuItemDto>>.Fail("Menü Bulunamadı", ErrorCodeEnum.NotFound);

            List<ResultMenuItemDto> dtos = mapper.Map<List<ResultMenuItemDto>>(menuItems);
            return ApiResponse<List<ResultMenuItemDto>>.SuccessResult(dtos);
        }
        catch (Exception)
        {
            return ApiResponse<List<ResultMenuItemDto>>.Fail("Menü getirilirken bir hata oluştu", ErrorCodeEnum.Exception);
        }
    }

    public async Task<ApiResponse<DetailMenuItemDto>> GetByIdMenuItem(int id)
    {
        MenuItem menuItem = await menuItemRepository.GetByIdAsync(id);
        if (menuItem is null) return ApiResponse<DetailMenuItemDto>.Fail("Menü Bulunamadı", ErrorCodeEnum.NotFound);

        DetailMenuItemDto detailMenuItemDto = mapper.Map<DetailMenuItemDto>(menuItem);
        return ApiResponse<DetailMenuItemDto>.SuccessResult(detailMenuItemDto);
    }

    public async Task<ApiResponse<object>> UpdateMenuItem(UpdateMenuItemDto updateMenuItemDto)
    {
        try
        {
            var response = await ValidationHelper.ValidateAsync(updateMenuItemValidator, updateMenuItemDto);
            if (!response.Success) return response;

            MenuItem menuItem = await menuItemRepository.GetByIdAsync(updateMenuItemDto.Id);
            if (menuItem is null) return ApiResponse<object>.Fail("Menü Bulunamadı", ErrorCodeEnum.NotFound);

            mapper.Map(updateMenuItemDto, menuItem);
            await menuItemRepository.UpdateAsync(menuItem);

            return ApiResponse<object>.SuccessNoDataResult("Menü güncellendi");
        }
        catch (Exception)
        {
            return ApiResponse<object>.Fail("Menü silinirken bir hata oluştu", ErrorCodeEnum.Exception);
        }
    }
}
