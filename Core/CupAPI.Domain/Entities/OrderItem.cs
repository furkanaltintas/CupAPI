﻿namespace CupAPI.Domain.Entities;

public sealed class OrderItem : BaseEntity
{
    public int OrderId { get; set; }
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }


    // Navigation properties
    public MenuItem? MenuItem { get; set; }
    public Order? Order { get; set; }
}
