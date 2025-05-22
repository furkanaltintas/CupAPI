using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CupAPI.Application.Common.Rules.CategoryRules;
public sealed class CategoryBusinessRules(ICategoryRepository categoryRepository) : BusinessRules
{
    public async Task<ApiResponse<Category>> CategoryShouldExist(int id)
    {
        var category = await categoryRepository.FirstOrDefaultAsync(c => c.Id == id, c => c.Include(c => c.MenuItems));

        if (category is null) return ApiResponse<Category>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);
        return ApiResponse<Category>.SuccessResult(category);
    }
}