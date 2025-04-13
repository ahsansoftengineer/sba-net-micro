using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data;
public partial class DBCntxt
{
  private static void EntityMappingConfig(ModelBuilder mb)
  {
    ConfigOneToMany(mb);
  }

  private static void ConfigOneToMany(ModelBuilder mb)
  {
    mb.Entity<ProjectzLookup>()
      .HasOne(p => p.ProjectzLookupBase)
      .WithMany(b => b.ProjectzLookup) // assumes navigation collection exists
      .HasForeignKey(p => p.ProjectzLookupBaseId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}