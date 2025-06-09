using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedBrand(this DBCtxProjectz context)
  {
    if (!context.Brands.Any(x => x.Id > 0))
    {
      context.Brands.AddRange(SeedzInfra.SeedDataEntityBase<Brand>());
      context.SaveChanges();
    }
  }
  public static void SeedBrand(this ModelBuilder builder)
  {
    builder.Entity<Brand>().HasData(SeedzInfra.SeedDataEntityBase<Brand>());
  }
  

}