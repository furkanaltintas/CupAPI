using CupAPI.Application.Dtos.MenuItemDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Menu.Queries.GetAllMenus;

public sealed class GetAllMenusQueryHandler(IMenuItemService menuItemService) : IRequestHandler<GetAllMenusQuery, ApiResponse<List<ResultMenuItemDto>>>
{
    public async Task<ApiResponse<List<ResultMenuItemDto>>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
    {
        return await menuItemService.GetAllAsync();
    }
}