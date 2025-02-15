using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Common;
public partial class AppDBContextProj
{
 
  private static void ConfigMicroServiceArch(ModelBuilder mb)
  {
     mb.Entity<UserBusinessIndustry>()
      .HasNoKey();
      // .HasKey(cs => new { cs.UserBusinessID, cs.IndustryID })
  }
}
