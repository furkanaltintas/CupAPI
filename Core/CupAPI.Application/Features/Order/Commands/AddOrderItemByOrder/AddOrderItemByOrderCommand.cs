using CupAPI.Application.Dtos.OrderDtos;
using MediatR;

namespace CupAPI.Application.Features.Order.Commands.AddOrderItemByOrder;

public sealed record AddOrderItemToOrderCommand(AddOrderItemToOrderDto AddOrderItemToOrderDto) : IRequest<ApiResponse<String>>;