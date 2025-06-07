using GLOB.Infra.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data;
// public partial class DBCtx : 
public partial class DBCtx
{
  public DbSet<ProjectzLookupBase> ProjectzLookupBases { get; set; }
  public DbSet<ProjectzLookup> ProjectzLookups { get; set; }
  
}
