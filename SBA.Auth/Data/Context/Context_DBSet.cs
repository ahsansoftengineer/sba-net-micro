using GLOB.Domain.Projectz;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public partial class DBCntxtProj 
{
  public DbSet<TestProj> TestProjs { get; set; }
  // public DbSet<AuthPermission> AuthPermission { get; set; }
  // public DbSet<AuthRole> AuthRole { get; set; }
}
