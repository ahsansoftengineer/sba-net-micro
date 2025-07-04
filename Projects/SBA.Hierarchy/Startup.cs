using SBA.Projectz.Data;
using SBA.Projectz.DI;

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
    srvc.Add_Projectz_Srvc(_config);
  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.Add_API_Default_Middlewares();

    if(!env.IsDevelopment()){
      app.Seed();
    }
  }
  public void RunFun()
  {
    
  }
}