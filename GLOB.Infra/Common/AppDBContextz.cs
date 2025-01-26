using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Common;
public partial class DBCntxt : IdentityDbContext<TestApiUser>
{
  public DBCntxt(DbContextOptions options) : base(options) { }
  public DbSet<TestEntity> TestEntitys { get; set; }
  public DbSet<TestParent> TestParents { get; set; }
  public DbSet<TestChild> TestChilds { get; set; }
  
  protected override void OnModelCreating(ModelBuilder builder)
  {
    // Step 2 Recalling Base OnModelCreating 
    // builder.ApplyConfiguration(new OrgConfig()); //
    // builder.Entity<Country>().HasData(SeedCountry.Data); //
    base.OnModelCreating(builder);
    //builder.Entity<Gender>().HasNoKey();
    //builder.Entity<Status>().HasNoKey();
    // builder.AddInitialEntityData();


  }
  // All below code Commented for future reference
  //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //
  //{
  //  optionsBuilder.LogTo(Console.WriteLine);
  //}
  //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //{
  //  base.OnConfiguring(optionsBuilder);
  //}
  //protected override void OnModelCreating(ModelBuilder builder)
  //{
  //  builder.ApplyConfigurationsFromAssembly(
  //    typeof(DonationDbContext).Assembly
  //  );
  //  base.OnModelCreating(builder);
  //}    
}