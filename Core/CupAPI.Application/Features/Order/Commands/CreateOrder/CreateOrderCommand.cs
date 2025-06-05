using CupAPI.Application.Dtos.OrderDtos;
using MediatR;

namespace CupAPI.Application.Features.Order.Commands.CreateOrder;

public sealed record CreateOrderCommand(CreateOrderDto CreateOrderDto) : IRequest<ApiResponse<String>>;
