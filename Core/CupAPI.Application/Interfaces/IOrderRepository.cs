﻿

using CupAPI.Domain.Entities;

namespace CupAPI.Application.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<List<Order>> GetAllOrderWithDetailAsync();
    Task<Order?> GetOrderByIdWithDetailAsync(int orderId);
}
