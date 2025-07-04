using GLOB.Infra.Data.Sqlz;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class DBCtxProjectz : DBCtx
{
  public DBCtxProjectz(DbContextOptions<DBCtxProjectz> options, IServiceProvider sp) : base(options, sp) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    ConfigManyToOne(mb);
    // ConfigMicroServiceArch(mb);
    // if (DOTNET_ENVIRONMENT != "Development")
    // {
      SeedProjectz.Seed(mb);
    // }

    base.OnModelCreating(mb);
  }
}
