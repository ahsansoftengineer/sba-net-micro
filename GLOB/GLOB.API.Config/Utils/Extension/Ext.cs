using Newtonsoft.Json;

namespace GLOB.API.Config.Extz;

public static partial class Ext
{
  public static void Print(this object obj, string? heading = null)
  {
    try
    {
      string result = JsonConvert.SerializeObject(obj, Formatting.Indented);
      result = result.Replace("\"", "");
      Console.WriteLine("--> [{0}] \n{1}", $"[{heading ?? "Object"}]", result);
    }
    catch (Exception ex)
    {
      Console.WriteLine("--> [Print Exception] : " + ex.Message);
    }
  }
  public static void Print(this Exception ex, string? heading = null)
  {
    ex.Message.Print($"[{heading ?? "Exception"}]");
  }
  public static void Print(this string value, string? heading = null)
  {
    Console.WriteLine("--> [{0}]\t-\t{1}\n", (heading ?? "[Message]"), value);
  }

  public static void Print()
  {
    Console.WriteLine("------------------------****-*-****------------------------");
  }
  
  public static T GetSrvc<T>(this IServiceProvider sp)
    where T : class
  {
    try
    {
      return sp.GetRequiredService<T>();
    }
    catch (Exception ex)
    {
      Print();
      $"Please Regiseter Service in DI {typeof(T).Name}".Print("DI");
      ex.Print();
      return null;
    }
  }
  public static T GetSrvc<T>(this IApplicationBuilder app)
    where T : notnull
  {
    return app.ApplicationServices.GetRequiredService<T>();
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
    if (string.IsNullOrEmpty(result)){
      string msg = $"Env has no Value for [{key}]";
      msg.Print();
      return msg;
    }
    return result;
  }
  public static int GetValueInt(this IConfiguration configuration, string key)
  {
    string result = configuration.GetValue(key, default(string));
    if (string.IsNullOrEmpty(result)){
      string msg = $"Env has no Value for [{key}]";
      msg.Print();
      return 0;
    }
    int value = 0;
    int.TryParse(result, out value);
    return value;
  }
}