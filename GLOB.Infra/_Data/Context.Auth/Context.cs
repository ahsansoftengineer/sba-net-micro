using GLOB.Domain.Auth;
using GLOB.Infra.Seedz;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data.Auth;
public partial class DBCntxtIdentity : IdentityDbContext<InfraUser, InfraRole, string>
{
  public DBCntxtIdentity(DbContextOptions options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder mb)
  {
    // mb.SeedInfra(); // Part of the Normal DBContext
    DBCntxt.EntityMappingConfig(mb);
    mb.SeedInfraIdentity();
    base.OnModelCreating(mb);
  }
}
