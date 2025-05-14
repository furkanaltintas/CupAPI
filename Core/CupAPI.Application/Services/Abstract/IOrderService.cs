using CupAPI.Application.Dtos.OrderDtos;

namespace CupAPI.Application.Services.Abstract
{
    public interface IOrderService
    {
        Task<ApiResponse<List<ResultOrderDto>>> GetAllAsync();
        Task<ApiResponse<DetailOrderDto>> GetByIdAsync(int id);
        Task<ApiResponse<String>> AddAsync(CreateOrderDto createOrderDto);
        Task<ApiResponse<String>> UpdateAsync(UpdateOrderDto updateOrderDto);
        Task<ApiResponse<String>> DeleteAsync(int id);
        Task<ApiResponse<String>> ChangeOrderStatusAsync(ChangeOrderStatusDto changeOrderStatusDto);
        Task<ApiResponse<String>> UpdateOrderWithItemAsync(AddOrderItemToOrderDto addOrderItemToOrderDto);
    }
}