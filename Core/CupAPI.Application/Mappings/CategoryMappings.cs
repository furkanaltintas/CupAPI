using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Mappings;

public static class CategoryMappings
{
    public static DetailCategoryDto ToGetCategoryResult(this Category category)
    {
        return new()
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}

public static class MenuItemMappings
{
}
