using FluentValidation;

namespace CupAPI.Application.Features.CafeInfo.Commands.CreateCafeInfo;

public sealed class CreateCafeInfoCommandValidator : AbstractValidator<CreateCafeInfoCommand>
{
    public CreateCafeInfoCommandValidator()
    {
    }
}