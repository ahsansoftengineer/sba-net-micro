using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Utils.Extz;

public static partial class Ext
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
      Console.WriteLine($"Please Regiseter Service in DI {typeof(TService).Name}");
      Console.WriteLine(ex.Message);
      return null;
    }
  }
  public static T GetSrvc<T>(this IApplicationBuilder app)
    where T : notnull
  {
    return app.ApplicationServices.GetRequiredService<T>();
  }
}