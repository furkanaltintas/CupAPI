using FluentValidation;

namespace CupAPI.Application.Features.CafeInfo.Commands.UpdateCafeInfo;

public sealed class UpdateCafeInfoCommandValidator : AbstractValidator<UpdateCafeInfoCommand>
{
    public UpdateCafeInfoCommandValidator()
    {
    }
}
