using CupAPI.Application.Dtos.TableDtos;
using MediatR;

namespace CupAPI.Application.Features.Table.Queries.GetAllTables;

public sealed record GetAllTablesQuery() : IRequest<ApiResponse<List<ResultTableDto>>>;