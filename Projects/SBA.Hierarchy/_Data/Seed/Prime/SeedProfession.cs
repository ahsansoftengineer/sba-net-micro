using GLOB.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class SeedProjectz
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