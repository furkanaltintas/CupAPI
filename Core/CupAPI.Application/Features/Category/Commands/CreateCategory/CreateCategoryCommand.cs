using CupAPI.Application.Dtos.CategoryDtos;
using MediatR;

namespace CupAPI.Application.Features.Category.Commands.CreateCategory;

public sealed record CreateCategoryCommand(CreateCategoryDto CreateCategoryDto) : IRequest<ApiResponse<String>>;
