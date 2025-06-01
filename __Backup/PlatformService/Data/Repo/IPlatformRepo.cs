using PlatformService.Models;

namespace PlatformService.Data;
public interface IPlatformRepo
{
  bool SaveChanges();
  IEnumerable<Platform> GetAllPlatforms();
  Platform GetPlatformById(int Id);
  void CreatePlatform(Platform platform);
}