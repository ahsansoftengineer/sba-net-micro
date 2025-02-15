using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Common;
// public partial class AppDBContextz : 
public partial class AppDBContextz
{
  public DbSet<TestInfra> TestInfras { get; set; }
  
}
