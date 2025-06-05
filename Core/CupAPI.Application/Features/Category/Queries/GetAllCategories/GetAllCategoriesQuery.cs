using CupAPI.Application.Dtos.CategoryDtos;
using MediatR;

namespace CupAPI.Application.Features.Category.Queries.GetAllCategories;

public sealed record GetAllCategoriesQuery : IRequest<ApiResponse<List<ResultCategoryDto>>>;