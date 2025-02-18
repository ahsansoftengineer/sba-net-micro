using GLOB.API.DI;
using SBA.Hierarchy.Config;
using SBA.Hierarchy.Context;
using SBA.Hierarchy.DI;

namespace SBA.Hierarchy;
public class Startup
{
  private IConfiguration _config { get; }

  public Startup(IConfiguration config)
  {
    _config = config;
  }

  public void ConfigureServices(IServiceCollection srvc)
  {
    
    srvc.AddDICommon();
    srvc.AddAutoMapper(typeof(MapInitCommonProj));
    srvc.AddAutoMapper(typeof(MapInitFullProj));
    srvc.AddSrvc(_config);
    srvc.AddDefaultExternalServices();

  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.AddDefaultExternalConfiguration(env);
    Console.WriteLine($"Current Environment: {env.EnvironmentName}");
    if(!env.IsDevelopment()){
      app.Seed();
    }
  }
}