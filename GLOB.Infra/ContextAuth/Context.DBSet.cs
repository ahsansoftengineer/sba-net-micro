using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Context.Auth;
public partial class DBCntxtIdentity
{
  public DbSet<TestInfra> TestInfras { get; set; }  
}
