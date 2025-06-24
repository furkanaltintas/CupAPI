using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Review.Commands.CreateReview;

public sealed class CreateReviewCommandHandler(IReviewService reviewService) : IRequestHandler<CreateReviewCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var response = await reviewService.AddAsync(request.CreateReviewDto);
        return response;
    }
}
