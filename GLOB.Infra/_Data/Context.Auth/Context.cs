using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data.Auth;
public partial class DBCntxtIdentity : IdentityDbContext<InfraUser, InfraRole, string>
{
  public DBCntxtIdentity(DbContextOptions options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder mb)
  {
    DBCntxt.EntityMappingConfig(mb);
    // mb.SeedInfraIdentity(); Handle From Auth Project
    base.OnModelCreating(mb);
  }
}
