using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data;
public static partial class Seeder
{
  // Proper Migration
  public static void Seed(this ModelBuilder mb)
  {
    mb.SeedPlatform();
  }
}