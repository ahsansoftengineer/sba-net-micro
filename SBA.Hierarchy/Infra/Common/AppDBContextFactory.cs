using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SBA.Hierarchy.Infra;
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDBContextProj>
{
  public AppDBContextProj CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<AppDBContextProj>();

    // Read connection string from appsettings.json
    var configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .Build();

    var connectionString = configuration.GetConnectionString("SqlConnection");

    optionsBuilder.UseSqlServer(connectionString);

    return new AppDBContextProj(optionsBuilder.Options);
  }
}