using CupAPI.Application.Dtos.CategoryDtos;
using MediatR;

namespace CupAPI.Application.Features.Category.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(int id) : IRequest<ApiResponse<DetailCategoryDto>>;