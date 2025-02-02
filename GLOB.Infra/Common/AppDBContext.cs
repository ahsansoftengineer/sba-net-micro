using GLOB.Domain.Entity;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Common;
public class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
  { 

  }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    mb.SeedTestStatus();
    mb.SeedTestParent();
    mb.SeedTestChild();
    
    base.OnModelCreating(mb);
  }
  public DbSet<TestChild> TestChilds { get; set; }
}