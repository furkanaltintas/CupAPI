using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Category.Commands.DeleteCategory
{
    public sealed class DeleteCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<DeleteCategoryCommand, ApiResponse<String>>
    {
        public async Task<ApiResponse<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await categoryService.DeleteAsync(request.id);
        }
    }
}