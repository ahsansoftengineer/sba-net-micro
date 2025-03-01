using GLOB.Domain.Auth;
using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Auth;
public partial class DBCntxtIdentity
{
  public DbSet<TestInfra> TestInfras { get; set; }
  public DbSet<AuthPermission> AuthPermission { get; set; }
  public DbSet<AuthRole> AuthRole { get; set; }
  
}
