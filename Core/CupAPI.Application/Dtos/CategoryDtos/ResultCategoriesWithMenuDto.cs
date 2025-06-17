using CupAPI.Application.Dtos.MenuItemDtos;

namespace CupAPI.Application.Dtos.CategoryDtos;

public record ResultCategoriesWithMenuDto : UpdateCategoryDto
{
    public List<CategoriesMenuItemDto>? MenuItems { get; set; }
}