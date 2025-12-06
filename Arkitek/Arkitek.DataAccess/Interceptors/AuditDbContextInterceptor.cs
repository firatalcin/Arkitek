using Arkitek.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Arkitek.DataAccess.Interceptors
{
    public class AuditDbContextInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry.Entity is not BaseEntity baseEntity)
                {
                    continue;
                }

                if (entry.State is EntityState.Added)
                {
                    eventData.Context.Entry(baseEntity).Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                    eventData.Context.Entry(baseEntity).Property(x => x.UpdatedAt).IsModified = false;
                }

                if (entry.State is EntityState.Modified)
                {
                    eventData.Context.Entry(baseEntity).Property(x => x.CreatedAt).IsModified = false;
                    eventData.Context.Entry(baseEntity).Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                }

                if (entry.State is EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    baseEntity.IsDeleted = true;
                    eventData.Context.Entry(baseEntity).Property(x => x.CreatedAt).IsModified = false;
                    eventData.Context.Entry(baseEntity).Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                }
            }


            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
