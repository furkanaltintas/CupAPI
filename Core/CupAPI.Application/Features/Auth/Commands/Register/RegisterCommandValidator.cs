using CupAPI.Application.Validators.User;
using FluentValidation;

namespace CupAPI.Application.Features.Auth.Commands.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.RegisterDto).SetValidator(new RegisterValidator());
    }
}