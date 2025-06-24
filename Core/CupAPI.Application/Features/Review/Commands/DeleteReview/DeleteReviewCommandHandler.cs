using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Review.Commands.DeleteReview;

public sealed class DeleteReviewCommandHandler(IReviewService reviewService) : IRequestHandler<DeleteReviewCommand, ApiResponse<String>>
{
    public async Task<ApiResponse<string>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var response = await reviewService.DeleteAsync(request.Id);
        return response;
    }
}
