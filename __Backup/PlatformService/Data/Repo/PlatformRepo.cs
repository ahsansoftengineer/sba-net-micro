using PlatformService.Models;

namespace PlatformService.Data;
public class PlatformRepo : IPlatformRepo
{
  private readonly AppDBContext _context;

  public PlatformRepo(AppDBContext context)
  {
    _context = context;
  }
  public void CreatePlatform(Platform platform)
  {
    if(platform == null)
    {
      throw new ArgumentNullException(nameof(platform));
    }
    _context.Platforms.Add(platform);
  }

  public IEnumerable<Platform> GetAllPlatforms()
  {
    return _context.Platforms.ToList();
  }

  public Platform GetPlatformById(int ID)
  {
    return _context.Platforms.FirstOrDefault(x => x.ID == ID);
  }

  public bool SaveChanges()
  {
    return _context.SaveChanges() >= 0;
  }
}