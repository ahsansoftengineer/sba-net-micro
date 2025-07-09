using Hangfire;
using Hangfire.Storage.SQLite;
using HangfireBasicAuthenticationFilter;
using Microsoft.Extensions.Options;

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
    IConfiguration config = app.GetSrvc<IConfiguration>();
    string prefix = config.GetValueStr("ASPNETCORE_ROUTE_PREFIX");
    string title = config.GetValueStr("Hangfire__Title");
    var users = config.GetValue<List<HangfireCustomBasicAuthenticationFilter>>("Hangfire__Users");

    app.UseHangfireDashboard($"/{prefix}/hangfire", new()
    {
      DashboardTitle = $"Hangfire {title}",
      Authorization = new[] {
        new HangfireCustomBasicAuthenticationFilter()
        {
          User = "guest",
          Pass = "guest"
        }
      }
      
    });
    app.UseEndpoints(endpoints =>
    {
      // http://localhost:1102/api/Job/v1/hangfire
      endpoints.MapHangfireDashboard($"/{prefix}/hangfire"); // Optionally specify path
    });

    app.Call_Hangfire_Recuring_Jobs();
  }
}