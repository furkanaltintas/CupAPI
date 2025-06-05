using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Order.Commands.UpdateOrder
{
    public sealed class UpdateOrderCommandHandler(IOrderService orderService) : IRequestHandler<UpdateOrderCommand, ApiResponse<String>>
    {
        public async Task<ApiResponse<string>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            return await orderService.UpdateAsync(request.UpdateOrderDto);
        }
    }
}