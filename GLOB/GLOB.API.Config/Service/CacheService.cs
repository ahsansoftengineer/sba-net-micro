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

    prefix = _config.GetValueStr("ASPNETCORE_ROUTE_PREFIX").Replace("/", ":");

    Console.WriteLine(prefix);
  }

  public async Task Set(CacheModel cm)
  {
    string Key = MrgKey(cm);
    var options = new DistributedCacheEntryOptions();
    if (cm.Duration != null)
      options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cm.Duration ?? 0);
    var json = JsonSerializer.Serialize(cm.Value);
    await _cache.SetStringAsync(Key, json, options);
  }

  public async Task<Object> Get(CacheModel cm)
  {
    string Key = MrgKey(cm);
    var json = await _cache.GetStringAsync(Key);
    return json == null ? default : JsonSerializer.Deserialize<object>(json);
  }

  public async Task Remove(CacheModel cm)
  {
    string Key = MrgKey(cm);
    await _cache.RemoveAsync(Key);
  }

  public async Task RemoveAll(CacheModel cm)
  {
    string Key = MrgKey(cm);
    var server = _redis.GetServer(_redis.GetEndPoints().First());
    var keys = server.Keys(pattern: $"{Key}*");
    foreach (var item in keys)
    {
      await _cache.RemoveAsync(item);
    }
  }
  public string MrgKey(CacheModel cm)
  {
    return $"{cm?.Prefix ?? prefix}:{cm.Controller}:{cm.EP}".Replace("/", ":");
  }
}

public class CacheModel
{
  public string? Prefix { get; set; }
  public string? Controller { get; set; }
  public string? EP { get; set; }
  public int? Duration { get; set; }
  public object? Value { get; set; }
}