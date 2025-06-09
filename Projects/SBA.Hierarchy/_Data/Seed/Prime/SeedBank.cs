using GLOB.Domain.Hierarchy;
using GLOB.Infra.Data.Sqlz;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class SeedProjectz
{
  public static void SeedBank(this DBCtxProjectz context)
  {
    if (!context.Banks.Any(x => x.Id > 0))
    {
      context.Banks.AddRange(SeedzInfra.SeedDataEntityBase<Bank>());
      context.SaveChanges();
    }
  }
  public static void SeedBank(this ModelBuilder builder)
  {
    builder.Entity<Bank>().HasData(SeedzInfra.SeedDataEntityBase<Bank>());
  }
  

}