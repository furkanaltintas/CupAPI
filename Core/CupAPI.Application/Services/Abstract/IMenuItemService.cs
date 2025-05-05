using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Common.Responses;

namespace CupAPI.Application.Services.Abstract;

public interface IMenuItemService
{
    Task<ApiResponse<List<ResultMenuItemDto>>> GetAllAsync();
    Task<ApiResponse<DetailMenuItemDto>> GetByIdAsync(int id);
    Task<ApiResponse<object>> AddAsync(CreateMenuItemDto createMenuItemDto);
    Task<ApiResponse<object>> UpdateAsync(UpdateMenuItemDto updateMenuItemDto);
    Task<ApiResponse<object>> DeleteAsync(int id);
}