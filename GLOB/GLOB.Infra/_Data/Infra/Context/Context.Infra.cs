using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data;

public class DBCtxInfra : DBCtx
{
  public DBCtxInfra(DbContextOptions<DBCtxInfra> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
  }
}
