
using GLOB.API.Config.DI;
using GLOB.API.DI;
using GLOB.API.Mapper;
using GLOB.Infra.Data;
using GLOB.Infra.Data.Auth;
using GLOB.Infra.DI;
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
    // srvc.Add_API_Default_Srvc(_config);
    // srvc.Config_DB_SQL<DBCtx, IUOW_Infra, UOW_Infra>(_config);
    // srvc.Config_DB_Identity<DBCtxIdentity, IUOW_Infra, UOW_Infra>(_config);
    // srvc.AddAutoMapper(typeof(API_Base_Mapper));
    // srvc.Add_API_Default_Srvc2();
  }
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    // app.Add_API_Default_Middlewares(env);
    // app.UseCors("CorsPolicyAllowAll");
   
    // app.UseHttpsRedirection();
    // if(!env.IsDevelopment()){
    //   app.Seed();
    // }
  }
}
