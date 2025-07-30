using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GLOB.Infra.Utils.Extz;

internal static partial class Ext
{
  internal static void Print(this object obj, string? heading = null)
  {
    try
    {
      string result = JsonConvert.SerializeObject(obj, Formatting.Indented);
      result = result.Replace("\"", "");
      Console.WriteLine("--> [{0}] \n{1}", heading ?? "Object", result);
    }
    catch (Exception ex)
    {
      Console.WriteLine("--> [Print Exception] : " + ex.Message);
    }
  }
  internal static void Print(this Exception ex, string? heading = null)
  {
    ex.Message.Print($"[{heading ?? "Exception"}]");
  }
  internal static void Print(this string value, string? heading = null)
  {
    Console.WriteLine("--> [{0}] \t{1}\n", heading ?? "[Message]", value);
  }
  private static void Prints(this string value)
  {
    Console.WriteLine(value);
  }

  internal static string GetWebUrl(this IConfiguration config)
  {
    string hostName = config.GetValueStr("ASPNETCORE_URLS");
    string prefix = config.GetValueStr("ASPNETCORE_ROUTE_PREFIX");
    return $"{hostName}/{prefix}";
  }
  internal static string GetValueStr(this IConfiguration config, string key)
  {
    string result = config.GetValue(key, default(string));
    if (string.IsNullOrEmpty(result))
    {
      string msg = $"Env has no Value for [{key}]";
      Console.WriteLine(msg);
      return msg;
    }
    return result;
  }
}