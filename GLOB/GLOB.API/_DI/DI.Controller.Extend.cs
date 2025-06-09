using GLOB.API.Config.DI;
using GLOB.Infra.Utils.MIddlewarez;

public static partial class DI_API
{
  public static void Add_Controller_Srvc_Extend(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Add_Controller(config, (opt) =>
    {
      opt.Filters.Add<FilterCacheActionGet>();
      opt.Filters.Add<FilterCacheActionGets>();
      opt.Filters.Add<FilterCacheActionSave>();
    });
  }
}