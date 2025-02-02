// using GLOB.Domain.Entity;
// using GLOB.Domain.Enums;
// using Microsoft.EntityFrameworkCore;

// namespace GLOB.Infra.Seed;
// public static partial class SeedData
// {
//   public static void TestStatus(this ModelBuilder mb)
//   {
//     mb.Entity<TestStatus>().HasData(
//       new TestStatus
//       {
//         Id = 1,
//         Title = "TestStatus 1",
//         Desc = "TestStatus 1 Desc",
//         Status = Status.Activate,
//       },
//       new TestStatus
//       {
//         Id = 2,
//         Title = "TestStatus 2",
//         Desc = "TestStatus 2 Desc",
//         Status = Status.DeActivate,
//       },
//       new TestStatus
//       {
//         Id = 3,
//         Title = "TestStatus 3",
//         Desc = "TestStatus 3 Desc",
//         Status = Status.None,
//       }
//     );
//   }
// }