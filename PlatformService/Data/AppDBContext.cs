using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data;
public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> opt)
  {

  }
}