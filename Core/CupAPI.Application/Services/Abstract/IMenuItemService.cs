using CupAPI.Application.Dtos.MenuItemDtos;

namespace CupAPI.Application.Services.Abstract;

public interface IMenuItemService
{
    Task<List<ResultMenuItemDto>> GetAllMenuItems();
    Task<DetailMenuItemDto> GetByIdMenuItem(int id);
    Task AddMenuItem(CreateMenuItemDto createMenuItemDto);
    Task UpdateMenuItem(UpdateMenuItemDto updateMenuItemDto);
    Task DeleteMenuItem(int id);
}