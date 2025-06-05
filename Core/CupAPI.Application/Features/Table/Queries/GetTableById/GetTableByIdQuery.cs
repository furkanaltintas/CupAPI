using CupAPI.Application.Dtos.TableDtos;
using MediatR;

namespace CupAPI.Application.Features.Table.Queries.GetTableById;

public sealed record GetTableByIdQuery(int Id) : IRequest<ApiResponse<DetailTableDto>>;