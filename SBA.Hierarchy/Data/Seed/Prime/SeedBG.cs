using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Data;
public static partial class Seeder
{
  public static void SeedBG(this AppDBContextProj context)
  {
    if (!context.BGs.Any(x => x.Id > 0))
    {
      context.BGs.AddRange(Seederz.SeedDataBaseEntity<BG>());
      context.SaveChanges();
    }
  }
  public static void SeedBG(this ModelBuilder builder)
  {
    builder.Entity<BG>().HasData(Seederz.SeedDataBaseEntity<BG>());
  }
  

}