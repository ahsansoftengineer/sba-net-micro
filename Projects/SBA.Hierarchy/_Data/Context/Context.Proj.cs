using GLOB.Infra.Data.Sqlz;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class DBCtxProjectz : DBCtx
{
  public DBCtxProjectz(DbContextOptions<DBCtxProjectz> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    ConfigManyToOne(mb);
    // ConfigMicroServiceArch(mb);
    SeedProjectz.Seed(mb);
    base.OnModelCreating(mb);
  }
}
