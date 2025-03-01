using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Context;
// public partial class DBCntxt : 
public partial class DBCntxtIdentity
{
  public DbSet<TestInfra> TestInfras { get; set; }
  
}
