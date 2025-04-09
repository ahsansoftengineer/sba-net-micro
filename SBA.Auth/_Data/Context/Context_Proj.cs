using GLOB.Infra.Data.Auth;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class ProjectzDBCntxt : DBCntxtIdentity
{
  public ProjectzDBCntxt(DbContextOptions<ProjectzDBCntxt> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    ConfigManyToOne(mb);
    // ConfigMicroServiceArch(mb);
    Seeder.Seed(mb);
    base.OnModelCreating(mb);
  }
}
