using GLOB.Infra.Data.Sqlz;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Extz;

public static partial class Exts_Infra
{
    public static async Task MigrateNoValidate<T>(
        this IServiceCollection srvc
    ) where T : DBCtx
    {
        var sp = srvc.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var context = scope.ServiceProvider.GetSrvc<T>();
        var migrator = context.GetService<IMigrator>();
        string con = context.Database.GetDbConnection().ConnectionString;
        con.EnsureDatabaseExists();
        // await context.Database.EnsureCreatedAsync();
        var pending = await context.Database.GetPendingMigrationsAsync();

        foreach (var migration in pending)
        {
            $"Applying: {migration} ✅".Print("EF Core");
            await migrator.MigrateAsync(migration);
            $"Done: {migration}".Print("EF Core");
        }

        if (!pending.Any())
        {
            "No pending migrations to apply. ✅".Print("EF Core");
        }
        await Task.CompletedTask;
    }
}