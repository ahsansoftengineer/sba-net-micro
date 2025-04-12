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
    mb.Entity<ProjectzLookupzz>()
      .HasOne(p => p.ProjectzLookupzzBase)
      .WithMany(b => b.ProjectzLookupzz) // assumes navigation collection exists
      .HasForeignKey(p => p.ProjectzLookupzzBaseId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}