using CupAPI.Application.Dtos.OrderItemDtos;

namespace CupAPI.Application.Dtos.OrderDtos;

public sealed class CreateOrderDto
{
    public int TableId { get; set; }
    public List<CreateOrderItemDto>? OrderItems { get; set; }
}