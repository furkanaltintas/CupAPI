using CupAPI.Domain.Enums;

namespace CupAPI.Application.Dtos.OrderDtos;

public sealed class ChangeOrderStatusDto
{
    public int OrderId { get; set; }
    public OrderType NewStatus { get; set; }
}