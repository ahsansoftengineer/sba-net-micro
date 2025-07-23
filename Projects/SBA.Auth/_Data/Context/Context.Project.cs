using GLOB.Domain.Model.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class DBCtxProjectz : IdentityDbContext<InfraUser, InfraRole, string>
{
  protected readonly IConfiguration _config;

  public string DOTNET_ENVIRONMENT { get; }
  public DBCtxProjectz(IServiceProvider sp, DbContextOptions<DBCtxProjectz> options) : base(options)
  {
    _config = sp.GetSrvc<IConfiguration>();
    DOTNET_ENVIRONMENT = _config.GetValueStr("DOTNET_ENVIRONMENT");

  }

  protected override void OnModelCreating(ModelBuilder mb)
  {

    ConfigManyToOne(mb);
    ConfigProjectzMapping(mb);
    // ConfigMicroServiceArch(mb);
    if (DOTNET_ENVIRONMENT != "Development")
    {
      SeedProjectz.Seed(mb);
    }
    base.OnModelCreating(mb);
  }
}
