using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Common;
public partial class AppDBContextProj 
{
  public DbSet<TestProj> TestProjs { get; set; }
  public DbSet<Org> Orgs { get; set; }
  public DbSet<Systemz> Systemzs { get; set; }
  public DbSet<BG> BGs { get; set; }
  public DbSet<LE> LEs { get; set; }
  public DbSet<OU> OUs { get; set; }
  public DbSet<SU> SUs { get; set; }
}
