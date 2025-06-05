using CupAPI.Application.Dtos.OrderDtos;
using MediatR;

namespace CupAPI.Application.Features.Order.Commands.ChangeOrderStatus;

public sealed record ChangeOrderStatusCommand(ChangeOrderStatusDto ChangeOrderStatusDto) : IRequest<ApiResponse<String>>;