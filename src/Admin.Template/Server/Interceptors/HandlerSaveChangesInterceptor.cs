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

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        BeforSaveChanges(eventData.Context!);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        BeforSaveChanges(eventData.Context!);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }


    private void BeforSaveChanges(DbContext context)
    {   
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
