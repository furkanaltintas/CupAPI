using CupAPI.Application.Dtos.TableDtos;
using MediatR;

namespace CupAPI.Application.Features.Table.Queries.GetTableByNumber;

public sealed record GetTableByNumberQuery(int tableNumber) : IRequest<ApiResponse<DetailTableDto>>;