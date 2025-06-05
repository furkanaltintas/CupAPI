using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Category.Commands.CreateCategory;

public sealed class CreateCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<CreateCategoryCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await categoryService.AddAsync(request.CreateCategoryDto);
    }
}
