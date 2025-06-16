using CupAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CupAPI.Persistence.Interceptors;

public class EntityAuditInterceptor(IHttpContextAccessor httpContextAccessor)
{
    public void ApplyAuditInformation(ChangeTracker changeTracker)
    {
        string username = httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";

        foreach (var entry in changeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.IsActive = true;
                    entry.Entity.IsDeleted = false;
                    entry.Entity.CreatedBy ??= username;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy ??= username;
                    break;

                case EntityState.Deleted:
                    // Soft delete
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.IsActive = false;
                    entry.Entity.UpdatedBy ??= username;
                    break;
            }
        }
    }
}