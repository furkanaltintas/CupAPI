using CupAPI.Application.Dtos.OrderItemDtos;
using FluentValidation;

namespace CupAPI.Application.Validators.OrderItem;

public sealed class UpdateOrderItemValidator : AbstractValidator<UpdateOrderItemDto>
{
    public UpdateOrderItemValidator()
    {
        RuleFor(o => o.Quantity)
            .NotEmpty().WithMessage("Sipariş adeti boş olamaz")
            .GreaterThan(0).WithMessage("Sipariş adeti 0'dan büyük olmak zorunda");
    }
}
