using CupAPI.Application.Dtos.ReviewDtos;
using MediatR;

namespace CupAPI.Application.Features.Review.Commands.UpdateReview;

public sealed record UpdateReviewCommand(UpdateReviewDto UpdateReviewDto) : IRequest<ApiResponse<String>>;