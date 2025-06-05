using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Menu.Queries.GetMenuById;

public sealed class GetMenuByIdQueryHandler(IMenuItemService menuItemService) : IRequestHandler<GetMenuByIdQuery, ApiResponse<DetailMenuItemDto>>
{
    public async Task<ApiResponse<DetailMenuItemDto>> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
    {
        return await menuItemService.GetByIdAsync(request.id);
    }
}