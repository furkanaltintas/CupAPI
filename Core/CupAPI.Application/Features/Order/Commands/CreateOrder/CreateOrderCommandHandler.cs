using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Order.Commands.CreateOrder;

public sealed class CreateOrderCommandHandler(IOrderService orderService) : IRequestHandler<CreateOrderCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        return await orderService.AddAsync(request.CreateOrderDto);
    }
}