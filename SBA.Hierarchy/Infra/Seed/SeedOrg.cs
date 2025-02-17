using GLOB.Domain.Entity;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Common;

namespace SBA.Hierarchy.Seed;
public static partial class Seeder
{
  public static void SeedOrg(this AppDBContextProj context)
  {
    if (!context.Orgs.Any(x => x.Id > 0))
    {
      context.Orgs.AddRange(Seederz.SeedDataBaseEntity<Org>());
      context.SaveChanges();
    }
  }
  public static void SeedOrg(this ModelBuilder builder)
  {
    builder.Entity<Org>().HasData(Seederz.SeedDataBaseEntity<Org>());
  }
  

}