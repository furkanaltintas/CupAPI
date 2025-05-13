using CupAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CupAPI.Persistence.Configurations;

public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .ToTable("OrderItems");

        builder
            .HasKey(oi => oi.Id);

        builder
            .Property(oi => oi.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(oi => oi.OrderId)
            .IsRequired();

        builder
            .Property(oi => oi.MenuItemId)
            .IsRequired();

        builder
            .Property(oi => oi.Quantity)
            .IsRequired();

        builder
            .Property(oi => oi.Price)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        //builder
        //    .HasOne(oi => oi.MenuItem)
        //    .WithMany(m => m.OrderItems)
        //    .HasForeignKey(oi => oi.MenuItemId)
        //    .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
