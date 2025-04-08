using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data.Auth;
public partial class DBCntxtIdentity
{
  public DbSet<TestInfra> TestInfras { get; set; }  
}
