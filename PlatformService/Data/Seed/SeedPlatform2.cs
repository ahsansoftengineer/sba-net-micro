using PlatformService.Models;

namespace PlatformService.Data;
public static partial class SeedData
{
  public static void SeedPlatform(this AppDBContext context)
  {
    Console.WriteLine("--> PlatformService Seeding Data ");
    List<Platform> data =
    [
      new Platform()
      {
        Name = "Dot Net",
        Publisher = "Microsoft",
        Cost = "Free"
      },
      new Platform()
      {
        Name = "SQL Server Express",
        Publisher = "Microsoft",
        Cost = "Free"
      },
      new Platform()
      {
        Name = "Kubernetes",
        Publisher = "Cloud Native Computing Foundation",
        Cost = "Free"
      },
    ];
    if(!context.Platforms.Any())
    {
      context.Platforms.AddRange(data);
    }
  }
}