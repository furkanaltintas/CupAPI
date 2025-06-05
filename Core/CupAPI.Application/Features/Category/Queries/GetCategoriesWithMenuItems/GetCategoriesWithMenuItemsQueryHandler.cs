using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Category.Queries.GetCategoriesWithMenuItems;

public sealed class GetCategoriesWithMenuItemsQueryHandler(ICategoryService categoryService) : IRequestHandler<GetCategoriesWithMenuItemsQuery, ApiResponse<List<ResultCategoriesWithMenuDto>>>
{
    public async Task<ApiResponse<List<ResultCategoriesWithMenuDto>>> Handle(GetCategoriesWithMenuItemsQuery request, CancellationToken cancellationToken)
    {
        return await categoryService.GetCategoriesWithMenuItemAsync();
    }
}