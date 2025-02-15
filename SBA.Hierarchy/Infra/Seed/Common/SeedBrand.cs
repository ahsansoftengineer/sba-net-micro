using GLOB.Domain.Entity;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Common;

namespace SBA.Hierarchy.Seed;
public static partial class Seeder
{
  public static void SeedBrand(this AppDBContextProj context)
  {
    if (!context.Brands.Any(x => x.Id > 0))
    {
      context.Brands.AddRange(Seederz.SeedDataBaseEntity<Brand>());
      context.SaveChanges();
    }
  }
  public static void SeedBrand(this ModelBuilder builder)
  {
    builder.Entity<Brand>().HasData(Seederz.SeedDataBaseEntity<Brand>());
  }
  

}