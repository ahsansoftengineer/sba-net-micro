using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedBG(this DBCntxtProj context)
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