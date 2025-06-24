using FluentValidation;

namespace CupAPI.Application.Features.Review.Commands.CreateReview;

public sealed class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(x => x.CreateReviewDto.UserId)
            .NotEmpty().WithMessage("Kullanıcı boş olamaz.");
        RuleFor(x => x.CreateReviewDto.Comment)
            .NotEmpty().WithMessage("Yorum boş olamaz")
            .MaximumLength(500).WithMessage("Yorum 500 karakterden fazla olamaz.");
        RuleFor(x => x.CreateReviewDto.Rating)
            .InclusiveBetween(1, 5).WithMessage("Puan 1 ile 5 arasında olmalıdır.");
    }
}