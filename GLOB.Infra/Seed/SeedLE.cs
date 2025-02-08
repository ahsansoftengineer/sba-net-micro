// using GLOB.Domain.Base;
// using GLOB.Domain.Entity;
// using GLOB.Infra.Common;
// using Microsoft.EntityFrameworkCore;

// namespace GLOB.Infra.Seed;
// public static partial class SeederInfra
// {
//   public static void SeedLE(this AppDBContextz context)
//   {
//     if (!context.LEs.Any(x => x.Id > 0))
//     {
//       context.LEs.AddRange(SeedDataLE<LE>());
//       context.SaveChanges();
//     }
//   }
//   public static void SeedLE(this ModelBuilder builder)
//   {
//     builder.Entity<LE>().HasData(SeedDataLE<LE>());
//   }
//   public static List<T> SeedDataLE<T>() where T : LE, new()
//   {
//     string className = typeof(T).Name;
//     List<T> list = new List<T>();
//     for (int i = 0; i < 3; i++)
//     {
//       list.Add(new T()
//       {
//         Id = i,
//         Title = $"{className} {i}",
//         Desc = $"{className} {i} Desc",
//         BGId = i
//       });
//     }
//     return list;
//   }

// }