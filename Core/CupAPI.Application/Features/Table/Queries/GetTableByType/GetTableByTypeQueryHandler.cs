using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Table.Queries.GetTableByType;

public sealed class GetTableByTypeQueryHandler(ITableService tableService) : IRequestHandler<GetTableByTypeQuery, ApiResponse<DetailTableDto>>
{
    public async Task<ApiResponse<DetailTableDto>> Handle(GetTableByTypeQuery request, CancellationToken cancellationToken)
    {
        return await tableService.GetByTypeAsync(request.TableType);
    }
}
