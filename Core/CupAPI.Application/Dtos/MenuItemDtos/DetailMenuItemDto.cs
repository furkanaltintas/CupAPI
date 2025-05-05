using CupAPI.Application.Dtos.CategoryDtos;

namespace CupAPI.Application.Dtos.MenuItemDtos;

public sealed record DetailMenuItemDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = false;

    public ResultCategoryDto Category { get; set; } = null!;
}
