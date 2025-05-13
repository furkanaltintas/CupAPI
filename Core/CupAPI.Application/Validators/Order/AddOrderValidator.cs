using CupAPI.Application.Dtos.OrderDtos;
using CupAPI.Application.Validators.OrderItem;
using FluentValidation;

namespace CupAPI.Application.Validators.Order;

public class AddOrderValidator : AbstractValidator<CreateOrderDto>
{
    public AddOrderValidator()
    {
        RuleFor(o => o.OrderItems)
            .NotNull().WithMessage("Sipariş öğeleri boş olamaz.")
            .Must(o => o.Count > 0).WithMessage("En az bir sipariş öğesi eklenmelidir.");

        RuleForEach(o => o.OrderItems).SetValidator(new AddOrderItemValidator());
    }
}