using GLOB.Domain.Model.Auth;
using GLOB.Infra.Data.Sqlz;
using GLOB.Infra.Utils.Extz;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GLOB.Infra.Data.Auth;
public partial class DBCtxIdentity : IdentityDbContext<InfraUser, InfraRole, string>
{
  protected readonly IConfiguration _config;

  public string DOTNET_ENVIRONMENT { get; }

  public DBCtxIdentity(DbContextOptions options, IServiceProvider sp) : base(options)
  {
    _config = sp.GetSrvc<IConfiguration>();
    DOTNET_ENVIRONMENT = _config.GetValueStr("DOTNET_ENVIRONMENT");
  }

  protected override void OnModelCreating(ModelBuilder mb)
  {
    DBCtx.EntityMappingConfig(mb);
    // mb.SeedInfraIdentity(); Handle From Auth Project
    base.OnModelCreating(mb);
  }
}
