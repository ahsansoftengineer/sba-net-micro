using System.Text.Json;
using GLOB.API.Config.Ext;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
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

    prefix = _config.GetValueStr("ASPNETCORE_ROUTE_PREFIX").Replace("/", "-");

    Console.WriteLine(prefix);
  }

  public async Task Set(CacheModel cm)
  {
    string Key = MrgKey(cm);
    var options = new DistributedCacheEntryOptions();
    if (cm.Duration != null)
      options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cm.Duration ?? 0);


    var json = JsonConvert.SerializeObject(cm.Value);
    await _cache.SetStringAsync(Key, json, options);
  }

  public async Task<Object> Get(CacheModel cm)
  {
    string? Key = MrgKey(cm);
    if (Key == null) return null;
    var json = await _cache.GetStringAsync(Key);
    if (json != null && !string.IsNullOrEmpty(json))
      return JsonConvert.DeserializeObject(json);
      
    return json ?? default;
  }

  public async Task Remove(CacheModel cm)
  {
    string? Key = MrgKey(cm);
    if (Key != null)
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
  public string? MrgKey(CacheModel? cm)
  {
    if (cm == null || cm?.Controller == null || cm?.Res == null) return null;
    return $"{cm?.Prefix ?? prefix}:{cm?.Controller ?? "Controller"}-{cm?.EP ?? "EP"}:{cm?.Res ?? "Res"}";
  }
}

public class CacheModel
{
  public string? Prefix { get; set; }
  public string? Controller { get; set; }
  public string? EP { get; set; }
  public string? Res { get; set; }
  public int? Duration { get; set; }
  public object? Value { get; set; }
}