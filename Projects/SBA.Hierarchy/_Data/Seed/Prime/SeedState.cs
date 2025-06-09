using GLOB.Domain.Hierarchy;
using GLOB.Infra.Data.Sqlz;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class SeedProjectz
{
  public static void SeedState(this DBCtxProjectz context)
  {
    if (!context.States.Any(x => x.Id > 0))
    {
      context.States.AddRange(SeedzInfra.SeedDataEntityBase<State>());
      context.SaveChanges();
    }
  }
  public static void SeedState(this ModelBuilder builder)
  {
    builder.Entity<State>().HasData(SeedzInfra.SeedDataEntityBase<State>());
  }
  

}