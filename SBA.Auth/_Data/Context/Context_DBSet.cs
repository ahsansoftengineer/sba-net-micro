using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class ProjectzDBCntxt 
{
  public DbSet<ProjectzEntityTest> TestProjs { get; set; }
  // public DbSet<UserPermission> UserPermission { get; set; }
  // public DbSet<AuthRole> AuthRole { get; set; }
}
