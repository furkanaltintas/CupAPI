using CupAPI.Application.Dtos.ReviewDtos;
using MediatR;

namespace CupAPI.Application.Features.Review.Queries.GetAllReviews;

public sealed record GetAllReviewsQuery() : IRequest<ApiResponse<List<ResultReviewDto>>>;