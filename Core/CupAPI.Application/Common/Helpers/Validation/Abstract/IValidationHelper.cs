namespace CupAPI.Application.Common.Helpers.Validation.Abstract;

public interface IValidationHelper
{
    Task<ApiResponse<TResult>> ValidateAsync<TModel, TResult>(TModel model);
}