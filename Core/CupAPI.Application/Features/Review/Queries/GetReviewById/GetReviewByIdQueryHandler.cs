using CupAPI.Application.Dtos.ReviewDtos;
using CupAPI.Application.Services.Abstract;
using MediatR;

namespace CupAPI.Application.Features.Review.Queries.GetReviewById;

public sealed class GetReviewByIdQueryHandler(IReviewService reviewService) : IRequestHandler<GetReviewByIdQuery, ApiResponse<DetailReviewDto>>
{
    public async Task<ApiResponse<DetailReviewDto>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await reviewService.GetByIdAsync(request.Id);
        return response;
    }
}

