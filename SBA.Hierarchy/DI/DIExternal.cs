
using GLOB.API.DI;

namespace SBA.Hierarchy.DI;
public static partial class DIExternal
{
  public static void AddExternalServices(this IServiceCollection services)
  {
    services.AddDefaultExternalServices();
  }

    public static void AddExternalConfiguration(this IApplicationBuilder app,
    IWebHostEnvironment env)
  {
    app.AddDefaultExternalConfiguration(env);
  }
  
}