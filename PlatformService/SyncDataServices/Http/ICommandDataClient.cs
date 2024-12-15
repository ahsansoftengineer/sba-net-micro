using PlatformService.DTO;

namespace PlatformService.SyncDataServices.Http;

public interface ICommandDataClient
{
  Task SendPlatformToCommand(PlatformReadDto dto);
}