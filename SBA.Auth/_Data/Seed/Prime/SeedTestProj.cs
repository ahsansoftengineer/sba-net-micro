using GLOB.Domain.Hierarchy;
using GLOB.Domain.Projectz;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedTestProj(this ProjectzDBCntxt context)
  {
    if (!context.TestProjs.Any(x => x.Id > 0))
    {
      context.TestProjs.AddRange(InfraSeeder.SeedDataBaseEntity<ProjectzEntityTest>());
      context.SaveChanges();
    }
  }
  public static void SeedTestProj(this ModelBuilder builder)
  {
    builder.Entity<ProjectzEntityTest>().HasData(InfraSeeder.SeedDataBaseEntity<ProjectzEntityTest>());
  }
  

}