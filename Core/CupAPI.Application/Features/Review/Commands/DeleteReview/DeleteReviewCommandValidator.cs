using FluentValidation;

namespace CupAPI.Application.Features.Review.Commands.DeleteReview;

public sealed class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
{
    public DeleteReviewCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Yorum bilgisi boş olamaz.");
    }
}