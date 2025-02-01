using GLOB.API;
using GLOB.API.DI;

namespace SBA.Hierarchy;
public class Startup
{
  public IConfiguration Configuration { get; }

  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddDICommon();
    services.AddAutoMapper(typeof(MapInitFull));
    services.AddExternalServices();
    // services.AddInrastr(Configuration);

  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.AddExternalConfiguration(env);
    app.UseCors("CorsPolicyAllowAll");
    app.UseHttpsRedirection();
  }
}