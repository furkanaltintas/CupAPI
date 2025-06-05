

using MediatR;

namespace CupAPI.Application.Features.Order.Commands.DeleteOrder;

public sealed record DeleteOrderCommand(int id) : IRequest<ApiResponse<String>>;