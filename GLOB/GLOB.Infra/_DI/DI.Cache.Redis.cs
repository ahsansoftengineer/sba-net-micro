using GLOB.Infra.Utils.MIddlewarez;
using GLOB.Infra.Utils.Srvcz;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace GLOB.Infra.DI;

public static partial class DI_Infra
{
  public static void Add_Infra_Cache_Redis(this IServiceCollection srvc, IConfiguration config)
  {

    srvc.AddSingleton<RedisCacheService>();
    srvc.AddSingleton<FilterCacheActionGet>();
    // srvc.AddSingleton<FilterCacheActionGets>();
    srvc.AddSingleton<FilterCacheActionSave>();

    srvc.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = config.GetConnectionString("Redis");
    });

    srvc.AddSingleton<IConnectionMultiplexer>(sp =>
      ConnectionMultiplexer.Connect(config.GetConnectionString("Redis")));

  }
}

