using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Review.Commands.UpdateReview;

public sealed class UpdateReviewCommandHandler(IReviewService reviewService) : IRequestHandler<UpdateReviewCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var response = await reviewService.UpdateAsync(request.UpdateReviewDto);
        return response;
    }
}
