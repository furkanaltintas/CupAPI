using CupAPI.Application.Dtos.TableDtos;
using FluentValidation;

namespace CupAPI.Application.Validators.Table;

public sealed class AddTableValidator : AbstractValidator<CreateTableDto>
{
    public AddTableValidator()
    {
        RuleFor(x => x.Type).IsInEnum().WithMessage("Geçersiz masa türü.");

        RuleFor(x => x.TableCode)
            .NotEmpty().WithMessage("Masa kodu boş olamaz.")
            .Length(3, 50).WithMessage("Masa kodu 3 ile 50 karakter arasında olmalıdır.");

        RuleFor(x => x.TableNumber).GreaterThan(0).WithMessage("Masa numarası sıfırdan büyük olmalıdır.");

        RuleFor(x => x.Capacity).GreaterThan(0).WithMessage("Kapasite sıfırdan büyük olmalıdır.");
    }
}