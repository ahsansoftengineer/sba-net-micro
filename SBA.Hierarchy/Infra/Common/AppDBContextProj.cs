using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
// public partial class AppDBContextz : 
public partial class AppDBContextProj : AppDBContextz
{
  public AppDBContextProj(DbContextOptions<AppDBContextProj> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    AppDBContextConfig(mb);
    mb.Seed();
    base.OnModelCreating(mb);
  }

  // public override int SaveChanges()
  // {
  //   var entries = ChangeTracker.Entries<BaseBEntity>();
  //   foreach (var entry in entries)
  //   {
  //     if (entry.State == EntityState.Added)
  //     {
  //       entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
  //     }
  //     if (entry.State == EntityState.Modified)
  //     {
  //       entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
  //     }
  //   }
  //   return base.SaveChanges();
  // }
}
