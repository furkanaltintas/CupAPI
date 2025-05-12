using CupAPI.Application.Dtos.OrderDtos;
using CupAPI.Application.Validators.OrderItem;
using FluentValidation;

namespace CupAPI.Application.Validators.Order;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderValidator()
    {
        RuleFor(x => x.TotalPrice)
            .GreaterThan(0).WithMessage("Toplam tutar 0'dan büyük olmalıdır.");

        RuleFor(x => x.CreatedAt)
            .NotEmpty().WithMessage("Oluşturulma tarihi boş olamaz.");

        RuleFor(x => x.UpdatedAt)
            .NotEmpty().WithMessage("Güncellenme tarihi boş olamaz.");

        RuleFor(x => x.OrderItems)
            .NotNull().WithMessage("Sipariş öğeleri boş olamaz.")
            .Must(x => x.Count > 0).WithMessage("En az bir sipariş öğesi eklenmelidir.");

        RuleForEach(x => x.OrderItems).SetValidator(new UpdateOrderItemValidator());
    }
}
