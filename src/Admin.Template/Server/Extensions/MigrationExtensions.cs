using Admin.Template.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Admin.Template.Server.Extensions;

public static class MigrationExtensions
{
    public static IApplicationBuilder MigrationDataBase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
        context.Database.Migrate();

        return app;
    }
}