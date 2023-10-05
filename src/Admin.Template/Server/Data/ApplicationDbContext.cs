using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using Admin.Template.Server.Data.Entity;
using Admin.Template.Server.Interceptors;

namespace Admin.Template.Server.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        builder.SeedDatas();

        foreach (var type in builder.Model.GetEntityTypes())
        {
            if (typeof(IHasIsDeleted).IsAssignableFrom(type.ClrType))
                builder.IsDeletedFilter(type.ClrType);
        }
    }
}
