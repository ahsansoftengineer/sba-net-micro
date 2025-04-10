using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedState(this ProjectzDBCntxt context)
  {
    if (!context.States.Any(x => x.Id > 0))
    {
      context.States.AddRange(InfraSeeder.SeedDataEntityBase<State>());
      context.SaveChanges();
    }
  }
  public static void SeedState(this ModelBuilder builder)
  {
    builder.Entity<State>().HasData(InfraSeeder.SeedDataEntityBase<State>());
  }
  

}