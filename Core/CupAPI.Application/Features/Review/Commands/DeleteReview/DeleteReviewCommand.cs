using MediatR;

namespace CupAPI.Application.Features.Review.Commands.DeleteReview;

public sealed record DeleteReviewCommand(int Id) : IRequest<ApiResponse<String>>;