using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using CupAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CupAPI.Persistence.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context) { }

    public async Task<List<Order>> GetAllOrderWithDetailAsync()
    {
        return await _context.Orders
            .Include(o => o.OrderItems)!
            .ThenInclude(oi => oi.MenuItem)
            .ThenInclude(mi => mi!.Category)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderByIdWithDetailAsync(int orderId)
    {
        return await _context.Orders
            .Where(o => o.Id == orderId)
            .Include(o => o.OrderItems)!
            .ThenInclude(oi => oi.MenuItem)
            .ThenInclude(mi => mi!.Category)
            .FirstOrDefaultAsync();
    }
}