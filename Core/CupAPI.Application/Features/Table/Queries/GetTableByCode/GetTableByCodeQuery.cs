using CupAPI.Application.Dtos.TableDtos;
using MediatR;

namespace CupAPI.Application.Features.Table.Queries.GetTableByCode;

public sealed record GetTableByCodeQuery(string TableCode) : IRequest<ApiResponse<DetailTableDto>>;