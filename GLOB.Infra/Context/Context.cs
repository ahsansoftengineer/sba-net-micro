using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Context;
public partial class AppDBContextz : DbContext
{
  public AppDBContextz(DbContextOptions options) : base(options) { }

  // TODO: NOTE: Here we need to work for Seeding Data
  protected override void OnModelCreating(ModelBuilder mb)
  {

    EntityMappingConfig(mb);
    // OnModelCreatingEnumConfig(mb);
    mb.Seed();

    base.OnModelCreating(mb);
  }
  protected virtual void OnModelCreatingEnumConfig(ModelBuilder mb)
  {
    foreach (var entityType in mb.Model.GetEntityTypes())
    {
      var properties = entityType.ClrType.GetProperties()
          .Where(p => p.Name == "Status" && p.PropertyType.IsEnum);

      foreach (var property in properties)
      {
        mb.Entity(entityType.ClrType)
          .Property(property.Name)
          .HasConversion<string>();
      }
    }
  }


}

// All below code Commented for future reference
// protected override void OnConfiguring(DbContextOptionsBuilder ob) //
// {
//  ob.LogTo(Console.WriteLine);
// }
// protected override void OnConfiguring(DbContextOptionsBuilder ob)
// {
//  base.OnConfiguring(ob);
// }
// protected override void OnModelCreating(ModelBuilder mb)
// {
//  mb.ApplyConfigurationsFromAssembly(
//    typeof(DonationDbContext).Assembly
//  );
//  base.OnModelCreating(mb);
// }    