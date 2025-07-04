using GLOB.API.Clientz;
using GLOB.Infra.Utils.MIddlewarez;

public static partial class DI_API
{


  public static void Add_API_Controller_Srvc_Extend(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Add_API_Config_Controller(config, (opt) =>
    {
      opt.Filters.Add<FilterCacheActionGet>();
      opt.Filters.Add<FilterCacheActionSave>();
      // opt.Filters.Add<FilterCacheActionGets>();
    });

    // srvc.AddSingleton<API_RabbitMQ_Base>();
    // srvc.AddSingleton<API_RabbitMQ_Base_Pubs>();

  }
}