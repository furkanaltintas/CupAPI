using CupAPI.Application.Validators.MenuItem;
using FluentValidation;

namespace CupAPI.Application.Features.Menu.Commands.CreateMenu;

public sealed class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.CreateMenuItemDto).SetValidator(new AddMenuItemValidator());
    }
}