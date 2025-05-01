using Microsoft.AspNetCore.Identity;
using GLOB.Infra.UOW_Projectz;
using GLOB.Domain.Auth;
using GLOB.Infra.Data.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace GLOB.Infra.DI;
public static partial class DI_Infra
{
  public static void Config_DB_Identity<TContext, TIUOW, TUOW>(this IServiceCollection srvc, IConfiguration config)
    where TContext : DBCntxtIdentity
    where TIUOW : class, IUOW_Infra
    where TUOW : UOW_Infra, TIUOW
  {
    srvc.Config_DB_SQL<TContext, TIUOW, TUOW>(config);

    // Configure Identity with roles
    // srvc.AddIdentity<InfraUser, InfraRole>()
    srvc.AddIdentity<InfraUser, InfraRole>()
        .AddEntityFrameworkStores<TContext>()
        .AddDefaultTokenProviders();
  }

}

// "ConnectionStrings": {
//   "SqlConnection": "Server=127.0.0.1,1430;Initial Catalog=SBA_Auth;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"
// },

