using CupAPI.Application.Dtos.OrderItemDtos;

namespace CupAPI.Application.Dtos.OrderDtos;

public sealed class AddOrderItemToOrderDto
{
    public int OrderId { get; set; }
    public CreateOrderItemDto? OrderItem { get; set; }
}
