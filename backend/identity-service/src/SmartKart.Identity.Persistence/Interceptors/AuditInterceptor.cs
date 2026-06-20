using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SmartKart.Identity.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartKart.Identity.Persistence.Interceptors
{
    public sealed class AuditInterceptor
    : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>>
            SavingChangesAsync(
                DbContextEventData eventData,
                InterceptionResult<int> result,
                CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            if (context is null)
            {
                return base.SavingChangesAsync(
                    eventData,
                    result,
                    cancellationToken);
            }

            foreach (var entry in context.ChangeTracker.Entries<AggregateRoot>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedOnUtc")
                         .CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("ModifiedOnUtc")
                         .CurrentValue = DateTime.UtcNow;
                }
            }

            return base.SavingChangesAsync(
                eventData,
                result,
                cancellationToken);
        }
    }
}
