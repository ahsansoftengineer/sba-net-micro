// using GLOB.Domain.Base;
// using GLOB.Infra.Data;
// using Microsoft.EntityFrameworkCore;

// namespace GLOB.Infra.Seed;
// public static partial class InfraSeeder
// {
//   // For DB Context (Normal) (Prod Automate) 
//   public static void SeedEntityShortParent(this DBCntxt context)
//   {
//     if (!context.EntityShortParentProjectzs.Any(x => x.Id > 0))
//     {
//       context.EntityShortParentProjectzs.AddRange(SeedDataBaseEntity<EntityShortParentProjectz>());
//       context.SaveChanges();
//     }
//   }
//   // For DB Context (Identity) (Dev CLI) 
//   public static void SeedEntityShortParent(this ModelBuilder builder)
//   {
//     builder.Entity<EntityShortParentProjectz>().HasData(SeedDataBaseEntity<EntityShortParentProjectz>());
//   }
// }