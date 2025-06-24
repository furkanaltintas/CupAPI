using CupAPI.Application.Dtos.ReviewDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Review.Queries.GetAllReviews;

public sealed class GetAllReviewsQueryHandler(IReviewService reviewService) : IRequestHandler<GetAllReviewsQuery, ApiResponse<List<ResultReviewDto>>>
{
    public async Task<ApiResponse<List<ResultReviewDto>>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
    {
        var response = await reviewService.GetAllAsync();
        return response;
    }
}