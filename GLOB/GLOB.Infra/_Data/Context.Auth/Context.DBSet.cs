using GLOB.Domain.Auth;
using GLOB.Infra.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Data.Auth;
public partial class DBCtxIdentity
{
  public DbSet<ProjectzLookupBase> ProjectzLookupBases { get; set; }
  public DbSet<ProjectzLookup> ProjectzLookups { get; set; }
  public DbSet<RefreshToken> RefreshTokens { get; set; }
}
