namespace CupAPI.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Categories { get; }
    IMenuItemRepository MenuItems { get; }
    IOrderItemRepository OrderItems { get; }
    IOrderRepository Orders { get; }
    ITableRepository Tables { get; }
    IUserRepository Users { get; }

    Task<int> SaveAsync();
}
