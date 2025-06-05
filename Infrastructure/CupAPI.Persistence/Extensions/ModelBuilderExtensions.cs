using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CupAPI.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static void AddGlobalQueryFilters(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var clrType = entity.ClrType;

            // "IsDeleted" özelliği olanlara filtre uygula
            if (clrType.GetProperty("IsDeleted") is not null)
            {
                var parameter = Expression.Parameter(entity.ClrType, "e");
                var property = Expression.Property(parameter, "IsDeleted");
                var condition = Expression.Equal(property, Expression.Constant(false));
                var lambda = Expression.Lambda(condition, parameter);

                // Bu noktada "HasQueryFilter" metodunu direkt olarak çağırıyoruz
                builder.Entity(entity.ClrType).HasQueryFilter(lambda);
            }
        }
    }
}
