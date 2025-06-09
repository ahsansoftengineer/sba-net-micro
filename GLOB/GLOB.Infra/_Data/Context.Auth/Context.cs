using GLOB.Domain.Model.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data.Auth;
public partial class DBCtxIdentity : IdentityDbContext<InfraUser, InfraRole, string>
{
  public DBCtxIdentity(DbContextOptions options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder mb)
  {
    DBCtx.EntityMappingConfig(mb);
    // mb.SeedInfraIdentity(); Handle From Auth Project
    base.OnModelCreating(mb);
  }
}
