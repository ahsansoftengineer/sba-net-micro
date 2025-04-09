using System.Threading.Tasks;
using GLOB.API.DI;
using SBA.Projectz.Data;
using SBA.Projectz.DI;

namespace SBA.Auth;
public class Startup
{
  private IConfiguration _config { get; }

  public Startup(IConfiguration config)
  {
    _config = config;
  }

  public void ConfigureServices(IServiceCollection srvc)
  {
    srvc.Add_API_DI_Common("SBA Authorization");
    srvc.Add_Projectz_Srvc(_config);
    srvc.Add_API_DefaultExternalServices();

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