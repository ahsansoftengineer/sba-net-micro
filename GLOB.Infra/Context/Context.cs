using GLOB.Domain.Base;
using GLOB.Infra.Seedz;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Context;
public partial class DBCntxt : DbContext
{
  public DBCntxt(DbContextOptions options) : base(options) { }

  // TODO: NOTE: Here we need to work for Seeding Data
  protected override void OnModelCreating(ModelBuilder mb)
  {

    EntityMappingConfig(mb);
    // OnModelCreatingEnumConfig(mb);
    // ConfigEnums(mb);
    mb.Seed();

    base.OnModelCreating(mb);
  }
  
  // // SaveChanges Handle in UnitOfWork
  // public override int SaveChanges()
  // {
  //   var entries = ChangeTracker.Entries<BetaEntity>();
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

  // protected override void OnConfiguring(DbContextOptionsBuilder ob)
  // {
  //   ob.LogTo(Console.WriteLine);
  //   base.OnConfiguring(ob);
  // }
}
