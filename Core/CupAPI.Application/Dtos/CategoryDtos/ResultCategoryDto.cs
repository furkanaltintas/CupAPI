namespace CupAPI.Application.Dtos.CategoryDtos;

public sealed record ResultCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
