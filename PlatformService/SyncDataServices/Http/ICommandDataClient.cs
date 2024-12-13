using PlatformService.DTO;

namespace PlatformService.SysnDataServices.Http;

public interface ICommandDataClient
{
  Task SendPlatformToCommand(PlatformReadDto dto);
}