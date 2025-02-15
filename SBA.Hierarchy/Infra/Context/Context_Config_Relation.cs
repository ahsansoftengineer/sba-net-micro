using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Common;
public partial class AppDBContextProj
{
 
  // private static void ConfigManyToOne(ModelBuilder mb)
  // {
  //   mb.Entity<City>()
  //     .HasOne(e => e.State)
  //     .WithMany(e => e.Citys)
  //     .HasForeignKey(e => e.StateId)
  //     .IsRequired(false);
  // }
}
