using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace GLOB.API.Config.Srvc;

public interface ICacheService
{
  Task SetAsync<T>(string key, T value, int? durationSeconds = 60);
  Task<T?> GetAsync<T>(string key);
  Task InvalidateAsync(string key);
  Task InvalidateByPrefixAsync(string prefix);
}

public class RedisCacheService : ICacheService
{
  private readonly IDistributedCache _cache;
  private readonly IConnectionMultiplexer _redis;

  public RedisCacheService(IDistributedCache cache, IConnectionMultiplexer redis)
  {
    _cache = cache;
    _redis = redis;
  }

  public async Task SetAsync<T>(string key, T value, int? durationSeconds = 60)
  {
    var options = new DistributedCacheEntryOptions();
    if (durationSeconds != null)
      options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(durationSeconds.Value);

    var json = JsonSerializer.Serialize(value);
    await _cache.SetStringAsync(key, json, options);
  }

  public async Task<T?> GetAsync<T>(string key)
  {
    var json = await _cache.GetStringAsync(key);
    return json == null ? default : JsonSerializer.Deserialize<T>(json);
  }

  public Task InvalidateAsync(string key) => _cache.RemoveAsync(key);

  public async Task InvalidateByPrefixAsync(string prefix)
  {
    var server = _redis.GetServer(_redis.GetEndPoints().First());
    var keys = server.Keys(pattern: $"{prefix}*");
    foreach (var key in keys)
    {
      await _cache.RemoveAsync(key);
    }
  }
}
