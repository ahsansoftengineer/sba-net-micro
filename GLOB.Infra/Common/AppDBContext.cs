
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
    SeedData.TestParent(mb);
    SeedData.TestChild(mb);
    
    base.OnModelCreating(mb);
  }
  public DbSet<TestChild> TestChilds { get; set; }
}