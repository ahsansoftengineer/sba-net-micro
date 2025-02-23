using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedBank(this AppDBContextProj context)
  {
    if (!context.Banks.Any(x => x.Id > 0))
    {
      context.Banks.AddRange(Seederz.SeedDataBaseEntity<Bank>());
      context.SaveChanges();
    }
  }
  public static void SeedBank(this ModelBuilder builder)
  {
    builder.Entity<Bank>().HasData(Seederz.SeedDataBaseEntity<Bank>());
  }
  

}