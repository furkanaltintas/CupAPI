using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Table.Queries.GetTableByCode;

public sealed class GetTableByCodeQueryHandler(ITableService tableService) : IRequestHandler<GetTableByCodeQuery, ApiResponse<DetailTableDto>>
{
    public async Task<ApiResponse<DetailTableDto>> Handle(GetTableByCodeQuery request, CancellationToken cancellationToken)
    {
        return await tableService.GetByCodeAsync(request.TableCode);
    }
}