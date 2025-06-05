using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Domain.Enums;
using MediatR;

namespace CupAPI.Application.Features.Table.Queries.GetTableByType;

public sealed record GetTableByTypeQuery(TableType TableType) : IRequest<ApiResponse<DetailTableDto>>;