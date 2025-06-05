using CupAPI.Application.Services.Concrete;
using MediatR;

namespace CupAPI.Application.Features.Menu.Commands.DeleteMenu
{
    public sealed class DeleteMenuCommandHandler(MenuItemService menuItemService) : IRequestHandler<DeleteMenuCommand, ApiResponse<String>>
    {
        public async Task<ApiResponse<string>> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            return await menuItemService.DeleteAsync(request.id);
        }
    }
}
