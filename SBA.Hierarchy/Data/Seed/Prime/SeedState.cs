using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedState(this DBCntxtProj context)
  {
    if (!context.States.Any(x => x.Id > 0))
    {
      context.States.AddRange(Seederz.SeedDataBaseEntity<State>());
      context.SaveChanges();
    }
  }
  public static void SeedState(this ModelBuilder builder)
  {
    builder.Entity<State>().HasData(Seederz.SeedDataBaseEntity<State>());
  }
  

}