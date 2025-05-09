using CupAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CupAPI.Persistence.Configurations;

public sealed class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder
            .ToTable("Tables");

        builder
            .HasKey(t => t.Id);

        builder
            .Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(t => t.Type)
            .IsRequired();

        builder
            .Property(t => t.TableCode)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(t => t.TableNumber)
            .IsRequired();

        builder
            .Property(t => t.Capacity)
            .IsRequired();

        builder
            .Property(t => t.IsActive)
            .IsRequired();
    }
}