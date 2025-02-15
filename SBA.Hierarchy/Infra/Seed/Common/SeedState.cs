using GLOB.Domain.Entity;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Common;

namespace SBA.Hierarchy.Seed;
public static partial class Seeder
{
  public static void SeedState(this AppDBContextProj context)
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