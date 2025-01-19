
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Common;
public class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
  { 

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // SeedData.Villa(modelBuilder);
    
    base.OnModelCreating(modelBuilder);
  }
//   public DbSet<Villa> Villas { get; set; }
//   public DbSet<VillaNumber> VillaNumber { get; set; }
//   public DbSet<Amenity> Amenity { get; set; }
}