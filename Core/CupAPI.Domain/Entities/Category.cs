namespace CupAPI.Domain.Entities;

public sealed class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;


    // Navigation properties
    public ICollection<MenuItem> MenuItems { get; set; } = null!;
}