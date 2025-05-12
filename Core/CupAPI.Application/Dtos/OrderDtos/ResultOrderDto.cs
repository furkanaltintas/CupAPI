using CupAPI.Application.Dtos.OrderItemDtos;
using CupAPI.Domain.Enums;

namespace CupAPI.Application.Dtos.OrderDtos;

public sealed class ResultOrderDto
{
    public int Id { get; set; }
    public int TableId { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderType Status { get; set; }
    public List<ResultOrderItemDto>? OrderItems { get; set; }
}