using CupAPI.Application.Dtos.OrderItemDtos;

namespace CupAPI.Application.Interfaces;

public interface IOrderItemService
{
    Task<ApiResponse<List<ResultOrderItemDto>>> GetAllAsync();
    Task<ApiResponse<DetailOrderItemDto>> GetByIdAsync(int id);
    Task<ApiResponse<String>> AddAsync(CreateOrderItemDto createOrderItemDto);
    Task<ApiResponse<String>> UpdateAsync(UpdateOrderItemDto updateOrderItemDto);
    Task<ApiResponse<String>> DeleteAsync(int id);
}
