using Hangfire;
using Hangfire.Storage.SQLite;

namespace SBA.Projectz.DI;

public static partial class DI_Projectz
{
  public static void Add_Hangfire(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.AddHangfire(opt =>
    {
      opt
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings(opt =>
        {

        });
      if (config.GetValueStr("DOTNET_ENVIRONMENT") == "Development")
      {
        opt.UseSQLiteStorage(Path.Combine("../../../", config.GetConnectionString("SQLite")), new SQLiteStorageOptions
        {
          QueuePollInterval = TimeSpan.FromSeconds(30), // Less frequent polling
          JobExpirationCheckInterval = TimeSpan.FromHours(6), // Less frequent expiration checks
          CountersAggregateInterval = TimeSpan.FromMinutes(30) // Less frequent counter updates
        });
      }
      else
      {
        opt.UseSqlServerStorage(config.GetConnectionString("SqlConnection"));
      }
    });
    srvc.AddHangfireServer();
    srvc.Add_Hangfire_Srvcs(config);
  }
  public static void Use_Hangfire(this IApplicationBuilder app)
  {
    app.UseHangfireDashboard();
    app.UseEndpoints(endpoints =>
    {
      endpoints.MapHangfireDashboard("/hangfire"); // Optionally specify path
    });

    app.Call_Hangfire_Recuring_Jobs();
  }
}