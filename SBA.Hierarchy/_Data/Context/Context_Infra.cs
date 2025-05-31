using GLOB.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public class DBCtxProjectzInfra : DBCtx
{
  public DBCtxProjectzInfra(DbContextOptions<DBCtxProjectzInfra> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
  }
}
