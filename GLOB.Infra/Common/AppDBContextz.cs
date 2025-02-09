using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Common;
public partial class AppDBContextz : DbContext
{
  public AppDBContextz(DbContextOptions options) : base(options) { }

  // TODO: NOTE: Here we need to work for Seeding Data
  protected override void OnModelCreating(ModelBuilder mb)
  {
    // Step 2 Recalling Base OnModelCreating 
    // mb.ApplyConfiguration(new OrgConfig()); //
    // mb.Entity<Country>().HasData(SeedCountry.Data); //
    AppDBContextConfig(mb);
    mb.Seed();
    base.OnModelCreating(mb);
    //mb.Entity<Gender>().HasNoKey();
    //mb.Entity<Status>().HasNoKey();
    // mb.AddInitialEntityData();
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