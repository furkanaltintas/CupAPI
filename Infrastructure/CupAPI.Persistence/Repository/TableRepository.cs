using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using CupAPI.Domain.Enums;
using CupAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CupAPI.Persistence.Repository;

public class TableRepository(AppDbContext context) : ITableRepository
{
    public async Task<Table> GetByCodeAsync(string tableCode)
    {
        return await context.Tables.FirstOrDefaultAsync(t => t.TableCode == tableCode);
    }

    public async Task<Table> GetByNumberAsync(int tableNumber)
    {
        return await context.Tables.FirstOrDefaultAsync(t => t.TableNumber == tableNumber);
    }

    public async Task<Table> GetByTypeAsync(TableType tableType)
    {
        return await context.Tables.FirstOrDefaultAsync(t => t.Type == tableType);
    }
}