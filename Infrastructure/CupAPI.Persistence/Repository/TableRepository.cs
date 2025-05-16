using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using CupAPI.Domain.Enums;
using CupAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CupAPI.Persistence.Repository;

public class TableRepository : GenericRepository<Table>, ITableRepository
{
    public TableRepository(AppDbContext context) : base(context) { }

    public async Task<Table?> GetByCodeAsync(string tableCode) => await _context.Tables.FirstOrDefaultAsync(t => t.TableCode == tableCode);

    public async Task<Table?> GetByNumberAsync(int tableNumber) => await _context.Tables.FirstOrDefaultAsync(t => t.TableNumber == tableNumber);

    public async Task<Table?> GetByTypeAsync(TableType tableType) => await _context.Tables.FirstOrDefaultAsync(t => t.Type == tableType);
}