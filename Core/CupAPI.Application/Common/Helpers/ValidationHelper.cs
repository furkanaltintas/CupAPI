using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CupAPI.Application.Common.Helpers;

public sealed class ValidationHelper(IServiceProvider serviceProvider) : IValidationHelper
{
    public async Task<ApiResponse<TResult>> ValidateAsync<TModel, TResult>(TModel model)
    {
        var validator = serviceProvider.GetService<IValidator<TModel>>();
        if (validator is null) return ApiResponse<TResult>.Fail(Messages.General.ValidatorNotFound, ErrorCodeEnum.ValidationError);

        var result = await validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            var errors = string.Join(" | ", result.Errors.Select(e => e.ErrorMessage));
            return ApiResponse<TResult>.Fail(errors, ErrorCodeEnum.ValidationError);
        }

        return ApiResponse<TResult>.SuccessNoDataResult();
    }
}