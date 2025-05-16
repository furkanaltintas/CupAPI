using CupAPI.Application.Interfaces;
using CupAPI.Persistence.Context;

namespace CupAPI.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public ICategoryRepository Categories { get; }
    public IMenuItemRepository MenuItems { get; }
    public IOrderRepository Orders { get; }
    public IOrderItemRepository OrderItems { get; }
    public ITableRepository Tables { get; }
    public IUserRepository Users { get; }

    public UnitOfWork(
        AppDbContext context,
        ICategoryRepository categories,
        IMenuItemRepository menuItems,
        IOrderRepository orders,
        IOrderItemRepository orderItems,
        ITableRepository tables,
        IUserRepository users)
    {
        _context = context;
        Categories = categories;
        MenuItems = menuItems;
        Orders = orders;
        OrderItems = orderItems;
        Tables = tables;
        Users = users;
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}