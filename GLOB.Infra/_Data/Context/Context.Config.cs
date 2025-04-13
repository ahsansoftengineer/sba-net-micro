using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data;
public partial class DBCntxt
{
  public static void EntityMappingConfig(ModelBuilder mb)
  {
    ConfigOneToMany(mb);
  }

  public static void ConfigOneToMany(ModelBuilder mb)
  {
    mb.Entity<ProjectzLookup>()
      .HasOne(p => p.ProjectzLookupBase)
      .WithMany(b => b.ProjectzLookup) // assumes navigation collection exists
      .HasForeignKey(p => p.ProjectzLookupBaseId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}