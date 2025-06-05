using CupAPI.Application.Dtos.OrderDtos;
using MediatR;

namespace CupAPI.Application.Features.Order.Commands.UpdateOrder;

public sealed record UpdateOrderCommand(UpdateOrderDto UpdateOrderDto) : IRequest<ApiResponse<String>>;