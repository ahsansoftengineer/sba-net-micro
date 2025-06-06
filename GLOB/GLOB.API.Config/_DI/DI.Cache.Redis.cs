using GLOB.API.Config.Filterz;
using GLOB.API.Config.Srvc;
using StackExchange.Redis;

namespace GLOB.API.Config.DI;

public static partial class DI_API_Config
{
  public static void Add_Cache_Redis(this IServiceCollection srvc, IConfiguration config)
  {

    srvc.AddScoped<ICacheService, RedisCacheService>();
    srvc.AddScoped<CacheActionFilter>();

    srvc.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = config.GetConnectionString("Redis");
    });

    srvc.AddSingleton<IConnectionMultiplexer>(sp =>
      ConnectionMultiplexer.Connect(config.GetConnectionString("Redis")));

    srvc.AddScoped<ICacheService, RedisCacheService>();
    srvc.AddScoped<CacheActionFilter>();

  }
}

