using Hangfire;
using Hangfire.Storage.SQLite;
using SBA.Projectz.Srvc;

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

        })
        .UseSQLiteStorage(config.GetConnectionString("SQLite"));
    });
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