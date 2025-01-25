
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
    SeedData.Test1(mb);
    
    base.OnModelCreating(mb);
  }
  public DbSet<Test1> Test1 { get; set; }
}