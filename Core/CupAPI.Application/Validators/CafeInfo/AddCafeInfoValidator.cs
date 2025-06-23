using CupAPI.Application.Dtos.CafeInfoDtos;
using FluentValidation;

namespace CupAPI.Application.Validators.CafeInfo;

public sealed class AddCafeInfoValidator : AbstractValidator<CreateCafeInfoDto>
{
    public AddCafeInfoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Kafe adi boş olamaz.")
            .MaximumLength(100).WithMessage("Kafe adi en fazla 100 karakter olabilir.");

        RuleFor(c => c.Address)
            .NotEmpty().WithMessage("Kafe adresi boş olamaz.")
            .MaximumLength(200).WithMessage("Kafe adresi en fazla 500 karakter olabilir.");

        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Kafe telefon numarasi boş olamaz.")
            .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Kafe telefon numarası geçerli bir formatta olmalı.");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Kafe e-posta adresi boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
    }
}