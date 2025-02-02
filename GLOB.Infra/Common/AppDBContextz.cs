using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Common;
// public partial class AppDBContextz : 
public partial class AppDBContextz
{
  public DbSet<TestEntity> TestEntitys { get; set; }
  public DbSet<TestStatus> TestStatuss { get; set; }
  public DbSet<TestParent> TestParents { get; set; }
  public DbSet<TestChild> TestChilds { get; set; }

}
