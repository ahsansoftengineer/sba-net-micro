using GLOB.Infra.Data.Auth;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class DBCntxtProj : DBCntxtIdentity
{
  public DBCntxtProj(DbContextOptions<DBCntxtProj> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    ConfigManyToOne(mb);
    // ConfigMicroServiceArch(mb);
    Seeder.Seed(mb);
    base.OnModelCreating(mb);
  }
}
