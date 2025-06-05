using CupAPI.Application.Dtos.OrderDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Order.Queries.GetAllOrders;

public sealed class GetAllOrdersQueryHandler(IOrderService orderService) : IRequestHandler<GetAllOrdersQuery, ApiResponse<List<ResultOrderDto>>>
{
    public async Task<ApiResponse<List<ResultOrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return await orderService.GetAllAsync();
    }
}
