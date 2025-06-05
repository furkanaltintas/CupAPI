using CupAPI.Application.Dtos.OrderDtos;
using MediatR;

namespace CupAPI.Application.Features.Order.Queries.GetOrderById;

public sealed record GetOrderByIdQuery(int id) : IRequest<ApiResponse<DetailOrderDto>>;