using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Table.Commands.UpdateTable;

public sealed record UpdateTableCommand(UpdateTableDto UpdateTableDto) : IRequest<ApiResponse<String>>;

public sealed class UpdateTableCommandHandler(ITableService tableService) : IRequestHandler<UpdateTableCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
    {
        return await tableService.UpdateAsync(request.UpdateTableDto);
    }
}