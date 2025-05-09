using CupAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CupAPI.Persistence.Configurations;

public sealed class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder
            .ToTable("MenuItems");

        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(m => m.CategoryId)
            .IsRequired();

        builder
            .Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Description)
               .HasMaxLength(500);

        builder
            .Property(m => m.Price)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder
            .Property(m => m.ImageUrl)
            .HasMaxLength(255);

        builder
            .Property(m => m.IsAvailable)
            .IsRequired();

        builder
            .HasOne(m => m.Category)
            .WithMany(c => c.MenuItems)
            .HasForeignKey(m => m.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
