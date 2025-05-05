using CupAPI.Application.Dtos.MenuItemDtos;

namespace CupAPI.Application.Dtos.CategoryDtos;

public sealed record DetailCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<ResultMenuItemDto> MenuItems { get; set; } = null!;
}