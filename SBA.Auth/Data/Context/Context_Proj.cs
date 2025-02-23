using GLOB.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class AppDBContextProj : DBCntxt
{
  public AppDBContextProj(DbContextOptions<AppDBContextProj> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    ConfigManyToOne(mb);
    // ConfigMicroServiceArch(mb);
    Seeder.Seed(mb);
    base.OnModelCreating(mb);
  }
}
