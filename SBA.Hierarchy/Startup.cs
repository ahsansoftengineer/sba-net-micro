using GLOB.API.DI;
using SBA.Projectz.Data;
using SBA.Projectz.DI;
using SBA.Projectz.Mapper;

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
    string ProjectzSwaggerName = _config.GetValue<string>("ProjectzSwaggerName") ?? string.Empty;
    string ProjectzRoutePrefix = _config.GetValue<string>("ProjectzRoutePrefix") ?? string.Empty;
    srvc.Add_API_DI_Common(ProjectzSwaggerName, ProjectzRoutePrefix);
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