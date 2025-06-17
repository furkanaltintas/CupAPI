namespace CupAPI.Application.Dtos.OrderItemDtos;

public class UpdateOrderItemDto : CreateOrderItemDto
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public decimal Price { get; set; }
}