using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Data;
public static partial class Seeder
{
  public static void SeedProfession(this AppDBContextProj context)
  {
    if (!context.Professions.Any(x => x.Id > 0))
    {
      context.Professions.AddRange(Seederz.SeedDataBaseEntity<Profession>());
      context.SaveChanges();
    }
  }
  public static void SeedProfession(this ModelBuilder builder)
  {
    builder.Entity<Profession>().HasData(Seederz.SeedDataBaseEntity<Profession>());
  }
  

}