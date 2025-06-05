using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Table.Queries.GetAllTables;

public sealed class GetAllTablesQueryHandler(ITableService tableService) : IRequestHandler<GetAllTablesQuery, ApiResponse<List<ResultTableDto>>>
{
    public async Task<ApiResponse<List<ResultTableDto>>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
    {
        return await tableService.GetAllAsync();
    }
}
