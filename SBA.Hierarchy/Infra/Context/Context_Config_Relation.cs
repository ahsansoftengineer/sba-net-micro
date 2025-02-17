using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Context;
public partial class AppDBContextProj
{
 
  private static void ConfigMicroServiceArch(ModelBuilder mb)
  {
    // mb.Entity<Mapping_UserBusinessProfession>()
    //   .HasNoKey();
    // mb.Entity<Mapping_UserBusinessProfession>()
    //   .HasNoKey();
      // .HasKey(cs => new { cs.UserBusinessID, cs.IndustryID })
  }
}
