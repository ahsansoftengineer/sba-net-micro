using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedProfession(this DBCtxProjectz context)
  {
    if (!context.Professions.Any(x => x.Id > 0))
    {
      context.Professions.AddRange(SeedzInfra.SeedDataEntityBase<Profession>());
      context.SaveChanges();
    }
  }
  public static void SeedProfession(this ModelBuilder builder)
  {
    builder.Entity<Profession>().HasData(SeedzInfra.SeedDataEntityBase<Profession>());
  }
  

}