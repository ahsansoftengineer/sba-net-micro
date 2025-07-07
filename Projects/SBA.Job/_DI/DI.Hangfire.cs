using Hangfire;
using Hangfire.Storage.SQLite;

namespace SBA.Projectz.DI;

public static partial class DI_Projectz
{
  public static void Add_Hangfire(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.AddHangfire(opt =>
    {
      opt.UseSimpleAssemblyNameTypeSerializer()
         .UseRecommendedSerializerSettings()
         .UseSQLiteStorage(config.GetConnectionString("SQLite"));
    });
  }  
}