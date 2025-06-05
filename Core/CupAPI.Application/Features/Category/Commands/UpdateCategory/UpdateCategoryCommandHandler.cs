using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Category.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<UpdateCategoryCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await categoryService.UpdateAsync(request.UpdateCategoryDto);
    }
}
