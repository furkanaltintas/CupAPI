using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Common.Rules.CategoryRules;
public sealed class CategoryBusinessRules(IGenericRepository<Category> categoryRepository)
{
    public async Task<ApiResponse<Category>> CategoryShouldExist(int id)
    {
        var category = await categoryRepository.GetByIdAsync(id);

        if(category is null) return ApiResponse<Category>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);
        return ApiResponse<Category>.SuccessResult(category);
    }
}