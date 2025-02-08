using GLOB.Domain.Entity;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Infra;

namespace SBA.Hierarchy.Seed;
public static partial class Seeder
{
  public static void SeedBG(this AppDBContextProj context)
  {
    if (!context.BGs.Any(x => x.Id > 0))
    {
      context.BGs.AddRange(SeederInfra.SeedDataBaseEntity<BG>());
      context.SaveChanges();
    }
  }
  public static void SeedBG(this ModelBuilder builder)
  {
    builder.Entity<BG>().HasData(SeederInfra.SeedDataBaseEntity<BG>());
  }
  

}