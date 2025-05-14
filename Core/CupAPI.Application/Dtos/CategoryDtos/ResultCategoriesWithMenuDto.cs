using CupAPI.Application.Dtos.MenuItemDtos;

namespace CupAPI.Application.Dtos.CategoryDtos;

public class ResultCategoriesWithMenuDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<CategoriesMenuItemDto>? MenuItems { get; set; }
}