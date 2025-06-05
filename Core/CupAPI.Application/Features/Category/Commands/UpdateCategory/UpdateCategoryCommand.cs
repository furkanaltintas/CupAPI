using CupAPI.Application.Dtos.CategoryDtos;
using MediatR;

namespace CupAPI.Application.Features.Category.Commands.UpdateCategory;

public sealed record UpdateCategoryCommand(UpdateCategoryDto UpdateCategoryDto) : IRequest<ApiResponse<String>>;