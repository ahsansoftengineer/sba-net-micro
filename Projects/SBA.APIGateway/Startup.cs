using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SBA.Projectz.DI;

namespace SBA.APIGateway;

public class Startup
{
  private IConfiguration _config { get; }

  public Startup(IConfiguration config)
  {
    _config = config;
  }

  public void ConfigureServices(IServiceCollection srvc)
  {
    srvc.Add_Projectz_Srvc(_config);
    srvc.AddOcelot(_config);
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.Add_API_Default_Middlewares();
    app.UseOcelot();
  }
  public void RunFun()
  {
    
  }
}
