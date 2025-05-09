using CupAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CupAPI.Persistence.Configurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .ToTable("Orders");

        builder
            .HasKey(o => o.Id);

        builder
            .Property(o => o.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(o => o.TableId)
            .IsRequired();

        builder
            .Property(o => o.TotalPrice)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder
            .Property(o => o.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Property(o => o.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Property(o => o.Status)
            .IsRequired();

        builder
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}