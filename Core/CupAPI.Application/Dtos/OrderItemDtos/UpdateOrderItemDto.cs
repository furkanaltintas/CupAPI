namespace CupAPI.Application.Dtos.OrderItemDtos;

public sealed class UpdateOrderItemDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}