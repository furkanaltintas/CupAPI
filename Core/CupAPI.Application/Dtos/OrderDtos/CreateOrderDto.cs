using CupAPI.Application.Dtos.OrderItemDtos;
using CupAPI.Domain.Enums;

namespace CupAPI.Application.Dtos.OrderDtos;

public sealed class CreateOrderDto
{
    public int TableId { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderType Status { get; set; } = OrderType.Pending;
    public List<CreateOrderItemDto>? OrderItems { get; set; }
}