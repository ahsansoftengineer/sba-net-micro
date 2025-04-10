using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data.Auth;
public partial class DBCntxtIdentity
{
  public DbSet<API_Infra_EntityTest> TestInfras { get; set; }  
}
