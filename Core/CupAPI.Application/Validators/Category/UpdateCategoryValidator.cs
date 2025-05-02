﻿using CupAPI.Application.Dtos.CategoryDtos;
using FluentValidation;

namespace CupAPI.Application.Validators.Category;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Kategori adı boş olamaz")
            .Length(3, 30).WithMessage("Kategori adı 3 ile 30 karakter arasında olmalıdır.");
    }
}
