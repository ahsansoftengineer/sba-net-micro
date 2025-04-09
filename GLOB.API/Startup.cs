
using GLOB.API.DI;
using GLOB.Infra.Data;
using GLOB.Infra.UOW;

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
    // srvc.Add_API_DI_Common();
    // srvc.Config_DB_SQL<DBCntxt, IUnitOfWorkInfra, UnitOfWorkInfra>(_config);
    // srvc.Config_DB_Identity<DBCntxtIdentity, IUnitOfWorkInfra, UnitOfWorkInfra>(_config);
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
