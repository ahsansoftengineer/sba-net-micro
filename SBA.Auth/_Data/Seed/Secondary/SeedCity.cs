// using GLOB.Domain.Hierarchy;
// using Microsoft.EntityFrameworkCore;

// namespace SBA.Projectz.Data;
// public static partial class Seeder
// {
//   public static void SeedCity(this ProjectzDBCntxt context)
//   {
//     if (!context.Citys.Any(x => x.Id > 0))
//     {
//       context.Citys.AddRange(SeedDataCity<City>());
//       context.SaveChanges();
//     }
//   }
//   public static void SeedCity(this ModelBuilder builder)
//   {
//     builder.Entity<City>().HasData(SeedDataCity<City>());
//   }
//   public static List<T> SeedDataCity<T>() where T : City, new()
//   {
//     string className = typeof(T).Name;
//     List<T> list = new List<T>();
//     for (int i = 1; i <= 3; i++)
//     {
//       list.Add(new T()
//       {
//         Id = i,
//         Name = $"{className} {i}",
//         Desc = $"{className} {i} Desc",
//         StateId = i
//       });
//     }
//     return list;
//   }

// }