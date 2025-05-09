using CupAPI.Domain.Enums;

namespace CupAPI.Domain.Entities;

public sealed class Order
{
    public int Id { get; set; }
    public int TableId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public OrderType Status { get; set; } = OrderType.Pending;
    public List<OrderItem> OrderItems { get; set; } = new();
}