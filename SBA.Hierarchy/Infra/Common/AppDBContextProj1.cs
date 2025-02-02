using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
// public partial class AppDBContextz : 
public partial class AppDBContextProj : AppDBContextz
{
  public AppDBContextProj(DbContextOptions options) : base(options) { }

}
