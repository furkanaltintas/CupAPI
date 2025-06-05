using CupAPI.Application.Dtos.OrderDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Order.Queries.GetOrderById;

public sealed class GetOrderByIdQueryHandler(IOrderService orderService) : IRequestHandler<GetOrderByIdQuery, ApiResponse<DetailOrderDto>>
{
    public async Task<ApiResponse<DetailOrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await orderService.GetByIdAsync(request.id);
    }
}