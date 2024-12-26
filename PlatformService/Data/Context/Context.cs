using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data;
public partial class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions options) : base(options)
  { }
  protected override void OnModelCreating(ModelBuilder mb)
  {
    // mb.Entity<UserCreator>().ToTable("UserCreator");
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