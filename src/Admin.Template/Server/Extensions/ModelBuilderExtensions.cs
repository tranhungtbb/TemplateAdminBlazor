using System.Reflection;
using Admin.Template.Server.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Admin.Template.Server.Extensions;

public static partial class ModelBuilderExtensions
{
    public static void IsDeletedFilter(this ModelBuilder modelBuilder, Type entityType)
    {
        IsDeletedFilterMethod.MakeGenericMethod(entityType)
            .Invoke(null, new object[] { modelBuilder });
    }

    static readonly MethodInfo IsDeletedFilterMethod = typeof(ModelBuilderExtensions)
               .GetMethods(BindingFlags.Public | BindingFlags.Static)
               .Single(t => t.IsGenericMethod && t.Name == "IsDeletedFilter");

    public static void IsDeletedFilter<TEntity>(this ModelBuilder modelBuilder) 
        where TEntity : class, IHasIsDeleted
    {
        modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.IsDeleted);
    }
}
