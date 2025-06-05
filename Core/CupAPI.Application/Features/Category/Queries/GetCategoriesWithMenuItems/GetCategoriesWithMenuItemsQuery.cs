using CupAPI.Application.Dtos.CategoryDtos;
using MediatR;

namespace CupAPI.Application.Features.Category.Queries.GetCategoriesWithMenuItems;

public sealed record GetCategoriesWithMenuItemsQuery : IRequest<ApiResponse<List<ResultCategoriesWithMenuDto>>>
{
    // Filtreleme işlemleri burada yapılacak
}