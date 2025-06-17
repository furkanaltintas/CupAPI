using CupAPI.Application.Dtos.MenuItemDtos;

namespace CupAPI.Application.Dtos.OrderItemDtos;

public class ResultOrderItemDto : UpdateOrderItemDto
{
    // Navigation properties
    public DetailMenuItemDto? MenuItem { get; set; }
}