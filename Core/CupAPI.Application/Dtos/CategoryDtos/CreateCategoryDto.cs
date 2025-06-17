namespace CupAPI.Application.Dtos.CategoryDtos;

public record CreateCategoryDto
{
    public string Name { get; set; } = string.Empty;
}
