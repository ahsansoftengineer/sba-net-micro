using GLOB.Domain.Base;
using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data;
// public partial class DBCntxt : 
public partial class DBCntxt
{
  public DbSet<API_Infra_EntityTest> TestInfras { get; set; }
  // public DbSet<EntityShortParentProjectz> EntityShortParentProjectzs { get; set; }
  // public DbSet<EntityShortProjectz> EntityShortProjectzs { get; set; }
  
}
