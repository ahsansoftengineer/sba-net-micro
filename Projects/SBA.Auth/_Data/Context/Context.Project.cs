using GLOB.Infra.Data.Auth;


namespace SBA.Projectz.Data;
public partial class DBCtxProjectz : DBCtxIdentity
{
  public DBCtxProjectz(IServiceProvider sp, DbContextOptions<DBCtxProjectz> options) : base(options, sp)
  {

  }

  protected override void OnModelCreating(ModelBuilder mb)
  {

    ConfigManyToOne(mb);
    ConfigProjectzMapping(mb);
    // ConfigMicroServiceArch(mb);
    if (DOTNET_ENVIRONMENT != "Development")
    {
      SeedProjectz.Seed(mb);
    }
    base.OnModelCreating(mb);
  }
}
