namespace CupAPI.Application.Dtos.CategoryDtos;

public record ResultCategoryDto : CreateCategoryDto
{
    public int Id { get; set; }
}
