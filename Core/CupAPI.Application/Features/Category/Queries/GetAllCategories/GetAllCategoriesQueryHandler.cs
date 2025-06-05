using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Category.Queries.GetAllCategories;

public sealed class GetAllCategoriesQueryHandler(ICategoryService categoryService) : IRequestHandler<GetAllCategoriesQuery, ApiResponse<List<ResultCategoryDto>>>
{
    public async Task<ApiResponse<List<ResultCategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        // Sayfalama olursa diye yapıldı
        return await categoryService.GetAllAsync();
    }
}