using GLOB.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class DBCtxProjectz : DBCtx
{
  public DBCtxProjectz(DbContextOptions<DBCtxProjectz> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    ConfigManyToOne(mb);
    // ConfigMicroServiceArch(mb);
    Seeder.Seed(mb);
    base.OnModelCreating(mb);
  }
}
