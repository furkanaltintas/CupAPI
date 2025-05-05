namespace CupAPI.Application.Dtos.CategoryDtos;

public sealed record CreateCategoryDto
{
    public string Name { get; set; } = string.Empty;
}
