using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Common.Rules.MenuItemRules;

public class MenuItemBusinessRules(IGenericRepository<MenuItem> menuItemRepository)
{
    public async Task<ApiResponse<MenuItem>> MenuItemShouldExist(int id)
    {
        var menuItem = await menuItemRepository.GetByIdAsync(id);

        if (menuItem is null) return ApiResponse<MenuItem>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);
        return ApiResponse<MenuItem>.SuccessResult(menuItem);
    }
}
