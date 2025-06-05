namespace CupAPI.Application.Dtos.CategoryDtos;

public sealed record UpdateCategoryDto
{
    public UpdateCategoryDto() { }

    public UpdateCategoryDto(int ıd, string name)
    {
        Id = ıd;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
