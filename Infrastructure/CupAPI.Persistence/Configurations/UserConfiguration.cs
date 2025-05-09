using CupAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CupAPI.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");

        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder
            .Property(u => u.AppUserId)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(u => u.Surname)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder
            .Property(u => u.Phone)
            .HasMaxLength(20);

        builder
            .Property(u => u.Role)
            .IsRequired()
            .HasMaxLength(50);
    }
}