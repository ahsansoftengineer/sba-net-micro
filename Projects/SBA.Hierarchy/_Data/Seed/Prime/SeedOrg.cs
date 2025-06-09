using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedOrg(this DBCtxProjectz context)
  {
    if (!context.Orgs.Any(x => x.Id > 0))
    {
      context.Orgs.AddRange(SeedzInfra.SeedDataEntityBase<Org>());
      context.SaveChanges();
    }
  }
  public static void SeedOrg(this ModelBuilder builder)
  {
    builder.Entity<Org>().HasData(SeedzInfra.SeedDataEntityBase<Org>());
  }
  

}