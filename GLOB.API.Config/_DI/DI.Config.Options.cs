using GLOB.API.Config.Configz;

namespace GLOB.API.Config.DI;
public static partial class DI_API_Config
{
  public static void Add_GLOB_API_Config_Options(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Configure<AppSettings>(config);
  }
}


