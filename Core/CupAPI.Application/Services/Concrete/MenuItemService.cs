using AutoMapper;
using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Interfaces;
using CupAPI.Application.Services.Abstract;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Services.Concrete;

public class MenuItemService(IGenericRepository<MenuItem> menuItemRepository, IMapper mapper) : IMenuItemService
{
    public async Task AddMenuItem(CreateMenuItemDto createMenuItemDto)
    {
        MenuItem menuItem = mapper.Map<MenuItem>(createMenuItemDto);
        await menuItemRepository.AddAsync(menuItem);
    }

    public async Task DeleteMenuItem(int id)
    {
        MenuItem menuItem = await menuItemRepository.GetByIdAsync(id);
        await menuItemRepository.DeleteAsync(menuItem);
    }

    public async Task<List<ResultMenuItemDto>> GetAllMenuItems()
    {
        List<MenuItem> menuItems = await menuItemRepository.GetAllAsync();
        List<ResultMenuItemDto> resultMenuItemDtos = mapper.Map<List<ResultMenuItemDto>>(menuItems);
        return resultMenuItemDtos;
    }

    public async Task<DetailMenuItemDto> GetByIdMenuItem(int id)
    {
        MenuItem menuItem = await menuItemRepository.GetByIdAsync(id);
        DetailMenuItemDto detailMenuItemDto = mapper.Map<DetailMenuItemDto>(menuItem);
        return detailMenuItemDto;
    }

    public async Task UpdateMenuItem(UpdateMenuItemDto updateMenuItemDto)
    {
        MenuItem menuItem = await menuItemRepository.GetByIdAsync(updateMenuItemDto.Id);
        mapper.Map(updateMenuItemDto, menuItem);
        await menuItemRepository.UpdateAsync(menuItem);
    }
}
