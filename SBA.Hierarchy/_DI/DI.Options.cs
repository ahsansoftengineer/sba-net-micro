using GLOB.API.Config.DI;

namespace SBA.Projectz.DI;
public static partial class DI_Projectz
{
  public static void Add_Projectz_Config_Options(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Add_GLOB_API_Config_Options(config);
  }
}