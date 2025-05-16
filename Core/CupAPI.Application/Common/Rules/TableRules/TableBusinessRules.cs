using CupAPI.Application.Common.Constants;
using CupAPI.Application.Common.Enums;
using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;

namespace CupAPI.Application.Common.Rules.TableRules;
public sealed class TableBusinessRules(
    IGenericRepository<Table> tableRepository) : BusinessRules
{
    public async Task<ApiResponse<Table>> TableShouldExist(int id)
    {
        var table = await tableRepository.GetByIdAsync(id);

        if (table is null)
            return ApiResponse<Table>.Fail(Messages.Table.ErrorWhileFetching, ErrorCodeEnum.NotFound);
        return ApiResponse<Table>.SuccessResult(table);
    }
}