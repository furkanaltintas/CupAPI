﻿using CupAPI.Application.Dtos.OrderDtos;
using CupAPI.Application.Validators.OrderItem;
using FluentValidation;

namespace CupAPI.Application.Validators.Order;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderValidator()
    {
        RuleFor(o => o.TotalPrice)
            .GreaterThan(0).WithMessage("Toplam tutar 0'dan büyük olmalıdır.");

        RuleFor(o => o.OrderItems)
            .NotNull().WithMessage("Sipariş öğeleri boş olamaz.")
            .Must(o => o.Count > 0).WithMessage("En az bir sipariş öğesi eklenmelidir.");

        RuleForEach(x => x.OrderItems).SetValidator(new UpdateOrderItemValidator());
    }
}
