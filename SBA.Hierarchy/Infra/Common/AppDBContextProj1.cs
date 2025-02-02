using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
// public partial class AppDBContextz : 
public partial class AppDBContextProj : AppDBContextz
{
  public AppDBContextProj(DbContextOptions options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder builder)
  {
    // Step 2 Recalling Base OnModelCreating 
    //builder.ApplyConfiguration(new OrgConfig()); //
    //builder.Entity<Country>().HasData(SeedCountry.Data); //
    base.OnModelCreating(builder);
    //builder.Entity<Gender>().HasNoKey();
    //builder.Entity<Status>().HasNoKey();
    //builder.AddInitialEntityData();
  }
}
