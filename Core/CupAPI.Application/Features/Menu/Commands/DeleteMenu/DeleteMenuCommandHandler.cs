using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Menu.Commands.DeleteMenu;

public sealed class DeleteMenuCommandHandler(IMenuItemService menuItemService) : IRequestHandler<DeleteMenuCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        return await menuItemService.DeleteAsync(request.id);
    }
}
