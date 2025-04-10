using GLOB.Domain.Base;
using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data;
// public partial class DBCntxt : 
public partial class DBCntxt
{
  public DbSet<API_Infra_EntityTest> TestInfras { get; set; }
  public DbSet<ProjectzEntityLookupBase> ProjectzEntityLookupBases { get; set; }
  public DbSet<ProjectzEntityLookup> ProjectzEntityLookups { get; set; }
  
}
