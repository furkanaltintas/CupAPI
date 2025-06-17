using CupAPI.Application.Dtos.MenuItemDtos;

namespace CupAPI.Application.Dtos.CategoryDtos;

public record DetailCategoryDto : UpdateCategoryDto
{
    public DetailCategoryDto() { }

    public DetailCategoryDto(int id, string name, ICollection<ResultMenuItemDto> menuItems)
    {
        Id = id;
        Name = name;
        MenuItems = menuItems;
    }

    public ICollection<ResultMenuItemDto> MenuItems { get; set; } = null!;
}