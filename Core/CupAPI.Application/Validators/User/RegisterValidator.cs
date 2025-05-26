using CupAPI.Application.Dtos.AuthDtos;
using FluentValidation;

namespace CupAPI.Application.Validators.User;

public sealed class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage("Ad alanı boş olamaz")
            .MinimumLength(2)
            .WithMessage("Ad alanı en az 2 karakter olmalıdır");

        RuleFor(r => r.Surname)
            .NotEmpty()
            .WithMessage("Soyad alanı boş olamaz")
            .MinimumLength(2)
            .WithMessage("Soyad alanı en az 2 karakter olmalıdır");

        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("Email alanı boş olamaz")
            .EmailAddress()
            .WithMessage("Geçersiz email adresi");

        RuleFor(r => r.Password)
            .NotEmpty()
            .WithMessage("Şifre alanı boş olamaz")
            .MinimumLength(6)
            .WithMessage("Ad alanı en az 6 karakter olmalıdır")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$")
            .WithMessage("Şifre en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");
    }
}