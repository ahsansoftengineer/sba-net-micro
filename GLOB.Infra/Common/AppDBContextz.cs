using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Common;
public partial class AppDBContextz : DbContext
{
  public AppDBContextz(DbContextOptions options) : base(options) { }

  // TODO: NOTE: Here we need to work for Seeding Data
  protected override void OnModelCreating(ModelBuilder mb)
  {

    // EntityMappingConfig(mb);

    // mb.ApplyConfiguration(new OrgConfig());
    // mb.Entity<Country>().HasData(SeedCountry.Data);
    // mb.Entity<Gender>().HasNoKey();

    base.OnModelCreating(mb);
  }
}

// All below code Commented for future reference
// protected override void OnConfiguring(DbContextOptionsBuilder ob) //
// {
//  ob.LogTo(Console.WriteLine);
// }
// protected override void OnConfiguring(DbContextOptionsBuilder ob)
// {
//  base.OnConfiguring(ob);
// }
// protected override void OnModelCreating(ModelBuilder mb)
// {
//  mb.ApplyConfigurationsFromAssembly(
//    typeof(DonationDbContext).Assembly
//  );
//  base.OnModelCreating(mb);
// }    