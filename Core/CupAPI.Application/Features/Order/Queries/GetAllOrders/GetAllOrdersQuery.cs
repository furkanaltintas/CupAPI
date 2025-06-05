using CupAPI.Application.Dtos.OrderDtos;
using MediatR;

namespace CupAPI.Application.Features.Order.Queries.GetAllOrders;

public sealed record GetAllOrdersQuery : IRequest<ApiResponse<List<ResultOrderDto>>>;