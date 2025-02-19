using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Context;
// public partial class AppDBContextz : 
public partial class AppDBContextz
{
  public DbSet<TestInfra> TestInfras { get; set; }
  
}
