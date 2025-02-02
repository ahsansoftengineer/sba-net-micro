using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
// public partial class AppDBContextz : 
public partial class AppDBContextProj 
{
  public DbSet<TestEntityInfra> TestEntityProj { get; set; }
  public DbSet<TestStatus> TestStatuss { get; set; }
  public DbSet<TestParent> TestParents { get; set; }
  public DbSet<TestChild> TestChilds { get; set; }
}
