using CupAPI.Application.Validators.MenuItem;
using FluentValidation;

namespace CupAPI.Application.Features.Menu.Commands.UpdateMenu;

public sealed class UpdateMenuCommandValidator: AbstractValidator<UpdateMenuCommand>
{
    public UpdateMenuCommandValidator()
    {
        RuleFor(x => x.UpdateMenuItemDto).SetValidator(new UpdateMenuItemValidator());
    }
}