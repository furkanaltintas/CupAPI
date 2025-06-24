using CupAPI.Application.Dtos.ReviewDtos;
using MediatR;

namespace CupAPI.Application.Features.Review.Queries.GetReviewById;

public sealed record GetReviewByIdQuery(int Id) : IRequest<ApiResponse<DetailReviewDto>>;