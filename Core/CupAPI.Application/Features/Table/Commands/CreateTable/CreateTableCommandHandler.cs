using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Table.Commands.CreateTable;

public sealed class CreateTableCommandHandler(ITableService tableService) : IRequestHandler<CreateTableCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(CreateTableCommand request, CancellationToken cancellationToken)
    {
        return await tableService.AddAsync(request.CreateTableDto);
    }
}
