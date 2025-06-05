using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Table.Commands.DeleteTable;

public sealed class DeleteTableCommandHandler(ITableService tableService) : IRequestHandler<DeleteTableCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(DeleteTableCommand request, CancellationToken cancellationToken)
    {
        return await tableService.DeleteAsync(request.id);
    }
}