using System.Text;
using System.Text.Json;
using PlatformService.DTO;
using PlatformService.SysnDataServices.Http;

namespace PlatformService.SyncDataServices.Http;

public class HttpCommandDataClient : ICommandDataClient
{
  private readonly HttpClient _httpClient;
  private readonly IConfiguration _config;

  public HttpCommandDataClient(
  HttpClient httpClient,
  IConfiguration config)
  {
    _httpClient = httpClient;
    _config = config;
  }
  public async Task SendPlatformToCommand(PlatformReadDto dto)
  {
    var httpContent = new StringContent(
      JsonSerializer.Serialize(dto),
      Encoding.UTF8,
      "application/json"
    );
    string? pathz = _config["CommandService"];
    
    var response = await _httpClient.PostAsync(pathz, httpContent);

    if (response.IsSuccessStatusCode)
    {
      Console.WriteLine("--> Sync POST to CommandService was OK!");
    }
    else
    {
      Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
    }
  }
}