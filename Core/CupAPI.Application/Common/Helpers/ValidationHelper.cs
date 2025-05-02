using CupAPI.Application.Common.Enums;
using CupAPI.Application.Common.Responses;
using FluentValidation;

namespace CupAPI.Application.Common.Helpers;

public static class ValidationHelper
{
    public static async Task<ApiResponse<object>> ValidateAsync<T>(IValidator<T> validator, T model)
    {
        var validate = await validator.ValidateAsync(model);
        if (!validate.IsValid) return ApiResponse<object>.Fail(string.Join(", ", validate.Errors.Select(e => e.ErrorMessage)), ErrorCodeEnum.ValidationError);
        return ApiResponse<object>.SuccessNoDataResult();
    }
}