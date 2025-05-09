namespace CupAPI.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;


    // Navigation properties
    public ICollection<MenuItem> MenuItems { get; set; } = null!;
}