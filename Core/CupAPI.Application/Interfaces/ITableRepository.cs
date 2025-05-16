using CupAPI.Domain.Entities;
using CupAPI.Domain.Enums;

namespace CupAPI.Application.Interfaces;

public interface ITableRepository : IGenericRepository<Table>
{
    Task<Table?> GetByCodeAsync(string tableCode);
    Task<Table?> GetByNumberAsync(int tableNumber);
    Task<Table?> GetByTypeAsync(TableType tableType);
}