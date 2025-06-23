using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Common.Rules.ReviewRules;

public sealed class ReviewBusinessRules(IReviewRepository reviewRepository) : BusinessRules
{
    public async Task<ApiResponse<Review>> ReviewShouldExist(int id)
    {
        var review = await reviewRepository.FirstOrDefaultAsync(c => c.Id == id);

        if (review is null) return ApiResponse<Review>.Fail(Messages.Review.ErrorWhileFetching, ErrorCodeEnum.NotFound);
        return ApiResponse<Review>.SuccessResult(review);
    }
}
