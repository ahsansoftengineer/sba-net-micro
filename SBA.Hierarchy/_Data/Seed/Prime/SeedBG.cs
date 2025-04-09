using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedBG(this ProjectzDBCntxt context)
  {
    if (!context.BGs.Any(x => x.Id > 0))
    {
      context.BGs.AddRange(InfraSeeder.SeedDataBaseEntity<BG>());
      context.SaveChanges();
    }
  }
  public static void SeedBG(this ModelBuilder builder)
  {
    builder.Entity<BG>().HasData(InfraSeeder.SeedDataBaseEntity<BG>());
  }
  

}