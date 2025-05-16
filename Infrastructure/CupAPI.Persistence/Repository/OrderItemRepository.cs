using CupAPI.Application.Interfaces;
using CupAPI.Domain.Entities;
using CupAPI.Persistence.Context;

namespace CupAPI.Persistence.Repository
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
