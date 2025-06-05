using CupAPI.Application.Dtos.CategoryDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Category.Queries.GetCategoryById;

public sealed class GetCategoryByIdQueryHandler(ICategoryService categoryService) : IRequestHandler<GetCategoryByIdQuery, ApiResponse<DetailCategoryDto>>
{
    public async Task<ApiResponse<DetailCategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await categoryService.GetByIdAsync(request.id);
    }
}