using CupAPI.Domain.Enums;

namespace CupAPI.Domain.Entities;

public sealed class Order : BaseEntity
{
    public int TableId { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderType Status { get; set; } = OrderType.Pending;


    // Navigation properties
    public List<OrderItem>? OrderItems { get; set; }
}