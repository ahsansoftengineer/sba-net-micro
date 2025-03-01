using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Context;
public partial class DBCntxtIdentity : IdentityDbContext
{
  public DBCntxtIdentity(DbContextOptions options) : base(options) { }

  // TODO: NOTE: Here we need to work for Seeding Data
  protected override void OnModelCreating(ModelBuilder mb)
  {

    // EntityMappingConfig(mb);
    // OnModelCreatingEnumConfig(mb);
    // ConfigEnums(mb);
    // mb.Seed();

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