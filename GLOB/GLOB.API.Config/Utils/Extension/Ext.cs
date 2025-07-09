namespace GLOB.API.Config.Extz;

public static partial class Extz
{
  public static T GetSrvc<T>(this IServiceProvider sp)
    where T: class
  {
    try
    {
      return sp.GetRequiredService<T>();
    } 
    catch(Exception ex) 
    {
      Console.WriteLine($"------------------------****-*-****------------------------");
      Console.WriteLine($"Please Regiseter Service in DI {typeof(T).Name}");
      Console.WriteLine(ex.Message);
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
      Console.WriteLine(msg);
      return msg;
    }
    return result;
  }
  public static int GetValueInt(this IConfiguration configuration, string key)
  {
    string result = configuration.GetValue(key, default(string));
    if (string.IsNullOrEmpty(result)){
      string msg = $"Env has no Value for [{key}]";
      Console.WriteLine(msg);
      return 0;
    }
    int value = 0;
    int.TryParse(result, out value);
    return value;
  }
}