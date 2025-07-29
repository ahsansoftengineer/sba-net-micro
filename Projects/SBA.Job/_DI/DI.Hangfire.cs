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
      if (config.GetValueStr("DOTNET_ENVIRONMENT") == "Development" && false)
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
    var option = app.GetSrvc<IOptions<Option_App>>().Value;

    var result = option.Hangfire.Users.Select(x => new HangfireCustomBasicAuthenticationFilter()
    {
      User = x.User,
      Pass = x.Pass
    }).ToList();
    
    app.UseHangfireDashboard($"/{option.ASPNETCORE_ROUTE_PREFIX}/hangfire"
      ,new DashboardOptions()
      {
        DashboardTitle = $"Hangfire {option.Hangfire.Title}",
        AppPath = $"swagger/index.html", // Not Required -> Back To Site
        DarkModeEnabled = true,
        // PrefixPath = $"{option.ASPNETCORE_ROUTE_PREFIX}",
        DefaultRecordsPerPage = 50,
        Authorization = result
      }
     );
    
    // app.UseEndpoints(endpoints =>
    // {
    //   // http://localhost:1102/api/Job/v1/hangfire
    //   endpoints.MapHangfireDashboard(new DashboardOptions()
    //   {
    //     DashboardTitle = "Use EP Hangfire Title",
    //     AppPath = $"/hangfire",
    //   });
    // });

    // app.Call_Hangfire_Recuring_Jobs();
  }
}