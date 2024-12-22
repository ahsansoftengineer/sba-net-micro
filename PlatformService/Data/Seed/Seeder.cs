using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data;
public static class Seeder
{
  public static void Seed(ModelBuilder mb)
  {
    // Prime
    mb.SeedPlatform();
  }
}