using GLOB.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Data;
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
