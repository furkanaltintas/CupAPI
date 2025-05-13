namespace CupAPI.Application.Dtos.OrderItemDtos;

public sealed class CreateOrderItemDto
{
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
}