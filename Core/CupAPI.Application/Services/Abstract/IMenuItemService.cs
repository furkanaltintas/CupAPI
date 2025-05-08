using CupAPI.Application.Dtos.MenuItemDtos;

namespace CupAPI.Application.Services.Abstract;

public interface IMenuItemService
{
    Task<ApiResponse<List<ResultMenuItemDto>>> GetAllAsync();
    Task<ApiResponse<DetailMenuItemDto>> GetByIdAsync(int id);
    Task<ApiResponse<String>> AddAsync(CreateMenuItemDto createMenuItemDto);
    Task<ApiResponse<String>> UpdateAsync(UpdateMenuItemDto updateMenuItemDto);
    Task<ApiResponse<String>> DeleteAsync(int id);
}