using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data;
public static class Seeder
{
  public static void Seed(this ModelBuilder mb)
  {
    // AppDBContext context
    // context.Database.Migrate();
    // Prime
    mb.SeedPlatform();
  }
}