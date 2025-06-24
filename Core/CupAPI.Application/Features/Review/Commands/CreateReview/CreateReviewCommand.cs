using CupAPI.Application.Dtos.ReviewDtos;
using MediatR;

namespace CupAPI.Application.Features.Review.Commands.CreateReview;

public  sealed record CreateReviewCommand(CreateReviewDto CreateReviewDto) : IRequest<ApiResponse<String>>;
