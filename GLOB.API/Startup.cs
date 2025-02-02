using GLOB.API.DI;

namespace GLOB.API;
public class Startup
{
  public IConfiguration Configuration { get; }

  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }
  public void ConfigureServices(IServiceCollection srvc)
  {
    srvc.AddDICommon();
    srvc.AddAutoMapper(typeof(MapInitFull));
    srvc.AddDefaultExternalServices();
  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.AddDefaultExternalConfiguration(env);
    app.UseCors("CorsPolicyAllowAll");
    app.UseHttpsRedirection();
  }
}
