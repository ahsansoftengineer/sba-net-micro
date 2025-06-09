namespace GLOB.API.Config.Extz;

public static partial class Extz
{
  public static TService GetSrvc<TService>(this IServiceProvider sp)
    where TService: class
  {
    try
    {
      return sp.GetRequiredService<TService>();
    } 
    catch(Exception ex) 
    {
      Console.WriteLine($"------------------------****-*-****------------------------");
      Console.WriteLine($"Please Regiseter Service in DI {nameof(TService)}");
      Console.WriteLine(ex.Message);
      return null;
    }
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
  public static T GetSrvc<T>(this IApplicationBuilder app)
    where T : notnull
  {
    return app.ApplicationServices.GetRequiredService<T>();
  }
}