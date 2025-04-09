// using GLOB.Domain.Base;
// using GLOB.Infra.Data;
// using Microsoft.EntityFrameworkCore;

// namespace GLOB.Infra.Seed;
// public static partial class InfraSeeder
// {
//   public static void SeedEntityShortProjectz(this DBCntxt context)
//   {
//     if (!context.EntityShortProjectzs.Any(x => x.Id > 0))
//     {
//       context.EntityShortProjectzs.AddRange(SeedDataBaseEntity<EntityShortProjectz>());
//       context.SaveChanges();
//     }
//   }
//   public static void SeedEntityShortProjectz(this ModelBuilder builder)
//   {
//     builder.Entity<EntityShortProjectz>().HasData(SeedDataBaseEntity<EntityShortProjectz>());
//   }
// }