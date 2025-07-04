using GLOB.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class SeedProjectz
{
  public static void SeedBG(this DBCtxProjectz context)
  {
    if (!context.BGs.Any(x => x.Id > 0))
    {
      context.BGs.AddRange(SeedzInfra.SeedDataEntityBase<BG>());
      context.SaveChanges();
    }
  }
  public static void SeedBG(this ModelBuilder builder)
  {
    builder.Entity<BG>().HasData(SeedzInfra.SeedDataEntityBase<BG>());
  }
  

}