using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Order.Commands.ChangeOrderStatus;

public sealed class ChangeOrderStatusCommandHandler(IOrderService orderService) : IRequestHandler<ChangeOrderStatusCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
    {
        return await orderService.ChangeOrderStatusAsync(request.ChangeOrderStatusDto);
    }
}