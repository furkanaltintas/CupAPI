using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Order.Commands.AddOrderItemByOrder;

public sealed class AddOrderItemToOrderCommandHandler(IOrderService orderService) : IRequestHandler<AddOrderItemToOrderCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(AddOrderItemToOrderCommand request, CancellationToken cancellationToken)
    {
        return await orderService.UpdateOrderWithItemAsync(request.AddOrderItemToOrderDto);
    }
}