using AutoMapper;
using CupAPI.Application.Common.Helpers.Validation.Abstract;

namespace CupAPI.Application.Common.Services;

public class CreateService(IMapper mapper, IValidationHelper validator)
{
    public async Task<ApiResponse<TResult>> HandleAsync<TDto, TEntity, TResult>(
        TDto dto,
        Func<TEntity, Task> addEntity,
        Func<TEntity, Task> saveEntity,
        string successMessage)
        where TDto : class
        where TEntity : class
    {
        var validateResponse = await validator.ValidateAsync<TDto, TResult>(dto);
        if (!validateResponse.Success) return validateResponse;

        var entity = mapper.Map<TEntity>(dto);
        await addEntity(entity);
        await saveEntity(entity);

        return ApiResponse<TResult>.SuccessNoDataResult(successMessage);
    }
}