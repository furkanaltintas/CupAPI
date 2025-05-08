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
    Task<ApiResponse<String>> AddAsync(CreateTableDto createTableDto);
    Task<ApiResponse<String>> UpdateAsync(UpdateTableDto updateTableDto);
    Task<ApiResponse<String>> DeleteAsync(int id);
}