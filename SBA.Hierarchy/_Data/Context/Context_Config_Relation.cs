using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class ProjectzDBCntxt
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
