using GLOB.API.Config.Filterz;
using GLOB.API.Config.Srvc;
using StackExchange.Redis;

namespace GLOB.API.Config.DI;

public static partial class DI_API_Config
{
  public static void Add_Cache_Redis(this IServiceCollection srvc, IConfiguration config)
  {

    srvc.AddSingleton<RedisCacheService>();
    srvc.AddSingleton<FilterCacheActionGet>();
    srvc.AddSingleton<FilterCacheActionGets>();
    srvc.AddSingleton<FilterCacheActionSave>();

    srvc.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = config.GetConnectionString("Redis");
    });

    srvc.AddSingleton<IConnectionMultiplexer>(sp =>
      ConnectionMultiplexer.Connect(config.GetConnectionString("Redis")));

  }
}

