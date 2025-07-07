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
        
        })
        .UseSQLiteStorage(config.GetConnectionString("SQLite"));
    });
  }
  public static void Use_Hangfire(this IApplicationBuilder app)
  {
    app.UseHangfireDashboard();
    app.UseEndpoints(endpoints =>
    {
      endpoints.MapHangfireDashboard("/hangfire"); // Optionally specify path
    });
  }  
}