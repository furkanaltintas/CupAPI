using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Order.Commands.DeleteOrder
{
    public sealed class DeleteOrderCommandHandler(IOrderService orderService) : IRequestHandler<DeleteOrderCommand, ApiResponse<String>>
    {
        public async Task<ApiResponse<string>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            return await orderService.DeleteAsync(request.id);
        }
    }
}