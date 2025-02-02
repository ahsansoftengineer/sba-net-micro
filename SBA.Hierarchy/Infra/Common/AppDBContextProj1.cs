using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
// public partial class AppDBContextz : 
public partial class AppDBContextProj : AppDBContextz
{
  public AppDBContextProj(DbContextOptions<AppDBContextProj> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    // Step 2 Recalling Base OnModelCreating 
    //mb.ApplyConfiguration(new OrgConfig()); //
    //mb.Entity<Country>().HasData(SeedCountry.Data); //
    base.OnModelCreating(mb);
    //mb.Entity<Gender>().HasNoKey();
    //mb.Entity<Status>().HasNoKey();
    //mb.AddInitialEntityData();
  }
}
