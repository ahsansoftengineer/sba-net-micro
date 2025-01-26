// using Microsoft.EntityFrameworkCore;

// namespace GLOB.Infra.Context.X
// {
//   public class DBCntxt : IdentityDbContext<ApiUser>
//   {
//     public DBCntxt(DbContextOptions options) : base(options) { }
//     public DbSet<Org> Orgs { get; set; }

//     protected override void OnModelCreating(ModelBuilder builder)
//     {
//       base.OnModelCreating(builder);
//       //builder.Entity<Gender>().HasNoKey();
//       //builder.Entity<Status>().HasNoKey();
//       builder.AddInitialEntityData();


//     }
//     // All below code Commented for future reference
//     //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //
//     //{
//     //  optionsBuilder.LogTo(Console.WriteLine);
//     //}
//     //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     //{
//     //  base.OnConfiguring(optionsBuilder);
//     //}
//     //protected override void OnModelCreating(ModelBuilder builder)
//     //{
//     //  builder.ApplyConfigurationsFromAssembly(
//     //    typeof(DonationDbContext).Assembly
//     //  );
//     //  base.OnModelCreating(builder);
//     //}    
//   }
// }