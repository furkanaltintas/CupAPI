using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Common.Responses;

namespace CupAPI.Application.Services.Abstract;

public interface IMenuItemService
{
    Task<ApiResponse<List<ResultMenuItemDto>>> GetAllMenuItems();
    Task<ApiResponse<DetailMenuItemDto>> GetByIdMenuItem(int id);
    Task<ApiResponse<object>> AddMenuItem(CreateMenuItemDto createMenuItemDto);
    Task<ApiResponse<object>> UpdateMenuItem(UpdateMenuItemDto updateMenuItemDto);
    Task<ApiResponse<object>> DeleteMenuItem(int id);
}