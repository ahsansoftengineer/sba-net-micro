using GLOB.Infra.Data.Auth;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class DBCtxProjectz : DBCtxIdentity
{
  public DBCtxProjectz(DbContextOptions<DBCtxProjectz> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    ConfigManyToOne(mb);
    ConfigProjectzMapping(mb);
    // ConfigMicroServiceArch(mb);
    Seeder.Seed(mb);
    base.OnModelCreating(mb);
  }
}
