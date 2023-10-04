using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Admin.Template.Server.Interceptors;

public class HandlerSaveChangesInterceptor : SaveChangesInterceptor
{
    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        BeforSaveChanges(eventData.Context);
        return base.SavedChanges(eventData, result);
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        BeforSaveChanges(eventData.Context);
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private static void BeforSaveChanges(DbContext? context)
    {
        if(context == null) return;
        
        foreach (var entry in context.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:

                    break;
                case EntityState.Modified:

                    break;
                default:
                    break;
            }
        }
    }
}
