using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GLOB.Infra.Utils.Extz;

public static partial class Ext
{
  public static void Print<T>(this T obj, string heading = "Msg")
    where T : class
  {
    try
    {
      string result = JsonConvert.SerializeObject(obj, Formatting.Indented);
      result = result.Replace("\"", "");
      result.Print(heading);
    }
    catch (Exception ex)
    {
      Console.WriteLine("--> Print Error : " + ex.Message);
    }
  }
  public static void Print(this Exception obj, string? heading = null)
  {
    obj.Message.Print($"[{heading ?? "Exception"}]");
  }
  public static void Print(this string value, string heading = "Msg")
  {
    Console.WriteLine("--> {0} \n\t{1}\n\n", heading, value);
  }
  public static string GetWebUrl(this IConfiguration configuration)
  {
    string hostName = configuration.GetValueStr("ASPNETCORE_URLS");
    string prefix = configuration.GetValueStr("ASPNETCORE_ROUTE_PREFIX");
    return $"{hostName}/{prefix}";
  }
  public static string GetValueStr(this IConfiguration configuration, string key)
  {
    string result = configuration.GetValue(key, default(string));
    if (string.IsNullOrEmpty(result))
    {
      string msg = $"Env has no Value for [{key}]";
      Console.WriteLine(msg);
      return msg;
    }
    return result;
  }
}