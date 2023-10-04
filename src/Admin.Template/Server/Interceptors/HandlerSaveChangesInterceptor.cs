using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Admin.Template.Server.Interceptors;

public class HandlerSaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly ClaimsPrincipal claimsPrincipal;
    public HandlerSaveChangesInterceptor(ClaimsPrincipal claimsPrincipal)
    {
        this.claimsPrincipal = claimsPrincipal;
    }

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

    private void BeforSaveChanges(DbContext? context)
    {
        if(context == null) return;
        
        foreach (var entry in context.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    if(entry.Entity is IHasCreationTime hasCreationTime)
                    {
                        hasCreationTime.Created = DateTime.UtcNow;
                    }
                    if(entry.Entity is IHasTrace hasTrace)
                    {
                        hasTrace.CreateBy = claimsPrincipal.GetUserId();
                        hasTrace.CreateByName = claimsPrincipal.GetUserName();
                    }
                    break;
                case EntityState.Modified:
                    if(entry.Entity is IHasModifyTime hasModifyTime)
                    {
                        hasModifyTime.ModifyDate = DateTime.UtcNow;
                    }
                    if(entry.Entity is IHasTrace trace)
                    {
                        trace.ModifyBy = claimsPrincipal.GetUserId();
                        trace.ModifyByName = claimsPrincipal.GetUserName();
                    }
                    break;
                case EntityState.Deleted:
                    if(entry.Entity is IHasIsDeleted hasIsDeleted)
                    {
                        hasIsDeleted.IsDeleted = true;
                        entry.State = EntityState.Modified;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
