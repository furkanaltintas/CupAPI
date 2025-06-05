using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Table.Queries.GetTableById;

public sealed class GetTableByIdQueryHandler(ITableService tableService) : IRequestHandler<GetTableByIdQuery, ApiResponse<DetailTableDto>>
{
    public async Task<ApiResponse<DetailTableDto>> Handle(GetTableByIdQuery request, CancellationToken cancellationToken)
    {
        return await tableService.GetByIdAsync(request.Id);
    }
}