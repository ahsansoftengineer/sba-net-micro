using GLOB.Infra.Data.Sqlz;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Extz;

public static partial class Exts_Infra
{
    public static async Task MigrateNoValidate<T>(
        this IServiceProvider services
    ) where T : DBCtx
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<T>();
        var migrator = scope.ServiceProvider.GetRequiredService<IMigrator>();
        var pending = await context.Database.GetPendingMigrationsAsync();

        foreach (var migration in pending)
        {
            $"➡️ Applying: {migration}".Print("EF Core");
            await migrator.MigrateAsync(migration);
            $"✅ Done: {migration}".Print("EF Core");
        }

        if (!pending.Any())
        {
            "✅ No pending migrations to apply.".Print("EF Core");
        }
    }
}