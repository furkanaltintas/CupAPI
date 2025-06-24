using FluentValidation;

namespace CupAPI.Application.Features.Review.Commands.UpdateReview;

public sealed class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
{
    public UpdateReviewCommandValidator()
    {
        RuleFor(x => x.UpdateReviewDto.Id).NotEmpty().WithMessage("Yorum boş olamaz.");
        RuleFor(x => x.UpdateReviewDto.Comment).NotEmpty().WithMessage("Yorum açıklaması boş olamaz.");
        RuleFor(x => x.UpdateReviewDto.Rating).InclusiveBetween(1, 5).WithMessage("Yorum puanı 1 ile 5 arasında olmalıdır.");
    }
}