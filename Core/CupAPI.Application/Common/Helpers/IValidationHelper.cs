namespace CupAPI.Application.Common.Helpers;

public interface IValidationHelper
{
    Task<ApiResponse<TResult>> ValidateAsync<TModel, TResult>(TModel model);
}