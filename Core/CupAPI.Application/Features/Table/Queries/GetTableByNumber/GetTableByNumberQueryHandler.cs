using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Table.Queries.GetTableByNumber;

public sealed class GetTableByNumberQueryHandler(ITableService tableService) : IRequestHandler<GetTableByNumberQuery, ApiResponse<DetailTableDto>>
{
    public async Task<ApiResponse<DetailTableDto>> Handle(GetTableByNumberQuery request, CancellationToken cancellationToken)
    {
        return await tableService.GetByNumberAsync(request.tableNumber);
    }
}