using GLOB.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Context;
// public partial class DBCntxt : 
public partial class DBCntxt
{
  public DbSet<TestInfra> TestInfras { get; set; }
  
}
