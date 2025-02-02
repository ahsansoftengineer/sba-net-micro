using GLOB.API;
using GLOB.API.DI;
using GLOB.Infra;
using SBA.Hierarchy.Infra;

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
    // srvc.AddAutoMapper(typeof(MapInitFull));
    srvc.AddSrvc(_config);
    srvc.AddDefaultExternalServices();

  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.AddDefaultExternalConfiguration(env);
    if(!env.IsDevelopment()){
      app.Seed();
    }
  }
}