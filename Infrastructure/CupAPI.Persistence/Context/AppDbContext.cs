using CupAPI.Domain.Entities;
using CupAPI.Persistence.Extensions;
using CupAPI.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace CupAPI.Persistence.Context;

public class AppDbContext : DbContext
{
    private readonly EntityAuditInterceptor _entityAuditInterceptor;

    public AppDbContext(DbContextOptions<AppDbContext> options, EntityAuditInterceptor entityAuditInterceptor) : base(options)
    {
        _entityAuditInterceptor = entityAuditInterceptor ?? throw new ArgumentNullException(nameof(entityAuditInterceptor));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.AddGlobalQueryFilters(); // soft delete filtrelemesi

    }

    public override int SaveChanges()
    {
        _entityAuditInterceptor.ApplyAuditInformation(ChangeTracker);
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        _entityAuditInterceptor.ApplyAuditInformation(ChangeTracker);
        return await base.SaveChangesAsync(cancellationToken);
    }


    #region DbSets
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Table> Tables => Set<Table>();
    public DbSet<User> Users => Set<User>();
    #endregion
}

public class AppDbContextFactory(EntityAuditInterceptor entityAuditInterceptor) : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CupAppDB;Trusted_Connection=True;");

        return new AppDbContext(optionsBuilder.Options, entityAuditInterceptor);
    }
}