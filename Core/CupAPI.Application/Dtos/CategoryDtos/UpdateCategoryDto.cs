namespace CupAPI.Application.Dtos.CategoryDtos;

public record UpdateCategoryDto : ResultCategoryDto
{
    public UpdateCategoryDto() { }

    public UpdateCategoryDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}