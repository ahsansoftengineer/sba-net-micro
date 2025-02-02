using GLOB.API;
using GLOB.API.DI;
using GLOB.Infra;
using SBA.Hierarchy.DI;

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
    services.AddExternalServices();
    services.AddInfra(_config);

  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.AddExternalConfiguration(env);
    app.UseCors("CorsPolicyAllowAll");
    app.UseHttpsRedirection();
  }
}