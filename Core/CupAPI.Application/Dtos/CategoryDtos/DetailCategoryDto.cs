using CupAPI.Application.Dtos.MenuItemDtos;

namespace CupAPI.Application.Dtos.CategoryDtos;

public sealed record DetailCategoryDto
{
    public DetailCategoryDto() { }

    public DetailCategoryDto(int id, string name, ICollection<ResultMenuItemDto> menuItems)
    {
        Id = id;
        Name = name;
        MenuItems = menuItems;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<ResultMenuItemDto> MenuItems { get; set; } = null!;
}