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
    mb.Entity<ProjectzLookupz>()
      .HasOne(p => p.ProjectzLookupzBase)
      .WithMany(b => b.ProjectzLookupz) // assumes navigation collection exists
      .HasForeignKey(p => p.ProjectzLookupzBaseId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}