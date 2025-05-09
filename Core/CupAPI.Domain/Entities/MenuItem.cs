namespace CupAPI.Domain.Entities;

public sealed class MenuItem : BaseEntity
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = false;


    // Navigation properties
    public Category Category { get; set; } = null!;
    public List<OrderItem>? OrderItems { get; set; }
}