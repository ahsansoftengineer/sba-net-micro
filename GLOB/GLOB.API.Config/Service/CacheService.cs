using System.Text.Json;
using GLOB.API.Config.Ext;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace GLOB.API.Config.Srvc;

public class RedisCacheService
{
  private readonly IDistributedCache _cache;
  private readonly IConnectionMultiplexer _redis;
  private readonly IConfiguration _config;
  private readonly string prefix;

  public RedisCacheService(IServiceProvider sp)
  {
    _cache = sp.GetSrvc<IDistributedCache>();
    _redis = sp.GetSrvc<IConnectionMultiplexer>(); ;
    _config = sp.GetSrvc<IConfiguration>();

    prefix = _config.GetValueStr("ASPNETCORE_ROUTE_PREFIX").Replace("/", ":") + ":";

    Console.WriteLine(prefix);
  }

  public async Task Set<T>(string key, T value, int? durationSeconds = 60)
  {
    key = $"{prefix}{key}";
    var options = new DistributedCacheEntryOptions();
    if (durationSeconds != null)
      options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(durationSeconds.Value);

    var json = JsonSerializer.Serialize(value);
    await _cache.SetStringAsync(key, json, options);
  }

  public async Task<T?> Get<T>(string key)
  {
    key = $"{prefix}{key}";
    var json = await _cache.GetStringAsync(key);
    return json == null ? default : JsonSerializer.Deserialize<T>(json);
  }

  public async Task Remove(string key)
  {
    key = $"{prefix}{key}";
    await _cache.RemoveAsync(key);
  }

  public async Task RemoveAll(string key)
  {
    key = $"{prefix}{key}";
    var server = _redis.GetServer(_redis.GetEndPoints().First());
    var keys = server.Keys(pattern: $"{key}*");
    foreach (var item in keys)
    {
      await _cache.RemoveAsync(item);
    }
  }
}
