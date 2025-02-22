using GLOB.Domain.Base;
using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Context;
public partial class AppDBContextProj
{
  private static void AddStatusEnum<TEntity>(ModelBuilder mb)
    where TEntity : BaseEntity
  {
    mb.Entity<TEntity>()
      .Property(e => e.Status)
      .HasConversion<string>();
  }
  private static void ConfigEnums(ModelBuilder mb)
  {
    // Simple
    AddStatusEnum<TestProj>(mb);
    AddStatusEnum<Org>(mb);
    AddStatusEnum<BG>(mb);
    AddStatusEnum<State>(mb);
    AddStatusEnum<Bank>(mb);
    AddStatusEnum<Brand>(mb);
    AddStatusEnum<Industry>(mb);
    AddStatusEnum<Profession>(mb);

    // -*

    AddStatusEnum<Systemz>(mb);
    AddStatusEnum<City>(mb);
    AddStatusEnum<LE>(mb);
    AddStatusEnum<OU>(mb);
    AddStatusEnum<SU>(mb);
   
  }

}
