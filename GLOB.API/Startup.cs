
using GLOB.API.Configz;
using GLOB.API.DI;
using GLOB.Infra.Data;
using GLOB.Infra.UOW_Projectz;

namespace GLOB.API;
// Note: Servicies are required when not in Micro Arch
// Current IOC Containers of Child Are being Used
public class Startup
{
  public IConfiguration _config { get; }

  public Startup(IConfiguration config)
  {
    _config = config;
  }
  public void ConfigureServices(IServiceCollection srvc)
  {
    string ProjectzSwaggerName = _config.GetValueStr("ProjectzSwaggerName");
    string ProjectzRoutePrefix = _config.GetValueStr("ProjectzRoutePrefix");
    srvc.Add_API_DI_Common(ProjectzSwaggerName, ProjectzRoutePrefix);

    
    // srvc.Config_DB_SQL<DBCntxt, IUOW_Infra, UOW_Infra>(_config);
    // srvc.Config_DB_Identity<DBCntxtIdentity, IUOW_Infra, UOW_Infra>(_config);
    // srvc.AddAutoMapper(typeof(API_Base_Mapper));
    // srvc.Add_API_DefaultExternalServices();
  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    // app.AddDefaultExternalConfiguration(env);
    // app.UseCors("CorsPolicyAllowAll");
   
    // app.UseHttpsRedirection();
    // if(!env.IsDevelopment()){
    //   app.Seed();
    // }
  }
}
