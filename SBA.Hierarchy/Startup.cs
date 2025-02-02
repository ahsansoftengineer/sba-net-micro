using GLOB.API;
using GLOB.API.DI;

namespace SBA.Hierarchy;
public class Startup
{
  private IConfiguration _config { get; }

  public Startup(IConfiguration config)
  {
    _config = config;
  }

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddDICommon();
    services.AddAutoMapper(typeof(MapInitFull));
    services.AddDefaultExternalServices();

  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.AddDefaultExternalConfiguration(env);
  }
}