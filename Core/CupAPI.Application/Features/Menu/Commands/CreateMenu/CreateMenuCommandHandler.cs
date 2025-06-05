using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Menu.Commands.CreateMenu;

public sealed class CreateMenuCommandHandler(IMenuItemService menuItemService) : IRequestHandler<CreateMenuCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        return await menuItemService.AddAsync(request.CreateMenuItemDto);
    }
}
