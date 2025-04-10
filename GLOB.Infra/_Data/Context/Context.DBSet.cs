using GLOB.Domain.Base;
using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data;
// public partial class DBCntxt : 
public partial class DBCntxt
{
  public DbSet<API_Infra_EntityTest> TestInfras { get; set; }
  public DbSet<ProjectzLookupzBase> ProjectzLookupzBases { get; set; }
  public DbSet<ProjectzLookupz> ProjectzLookupzs { get; set; }
  
}
