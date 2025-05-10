using CupAPI.Application.Dtos.MenuItemDtos;
using FluentValidation;

namespace CupAPI.Application.Validators.MenuItem;

public sealed class AddMenuItemValidator : AbstractValidator<CreateMenuItemDto>
{
    public AddMenuItemValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Menü adı boş olamaz")
            .Length(3, 30).WithMessage("Menü adı 3 ile 30 karakter arasında olmalıdır.");

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Menü açıklaması boş olamaz")
            .MaximumLength(500).WithMessage("Menü açıklaması 500 karakterden fazla olamaz");

        RuleFor(c => c.Price)
            .GreaterThan(0)
            .WithMessage("Fiyat 0'dan büyük olmalıdır.");

        RuleFor(c => c.ImageUrl)
            .NotEmpty().WithMessage("Resim URL'si boş olamaz");
    }
}