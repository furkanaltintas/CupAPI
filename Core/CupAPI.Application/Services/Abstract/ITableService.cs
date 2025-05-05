using CupAPI.Application.Common.Responses;
using CupAPI.Application.Dtos.TableDtos;
using CupAPI.Domain.Enums;

namespace CupAPI.Application.Services.Abstract;

public interface ITableService
{
    Task<ApiResponse<List<ResultTableDto>>> GetAllAsync();
    Task<ApiResponse<DetailTableDto>> GetByIdAsync(int id);
    Task<ApiResponse<DetailTableDto>> GetByCodeAsync(string tableCode);
    Task<ApiResponse<DetailTableDto>> GetByNumberAsync(int tableNumber);
    Task<ApiResponse<DetailTableDto>> GetByTypeAsync(TableType tableType);
    Task<ApiResponse<object>> AddAsync(CreateTableDto createTableDto);
    Task<ApiResponse<object>> UpdateAsync(UpdateTableDto updateTableDto);
    Task<ApiResponse<object>> DeleteAsync(int id);
}
