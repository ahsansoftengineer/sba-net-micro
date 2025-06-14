namespace GLOB.API.Config.Configz;

public class ClientzHttpSettings
{
  public string Gateway { get; set; } = string.Empty;
  public string Auth { get; set; } = string.Empty;
  public string Hierarchy { get; set; } = string.Empty;
}

public class ClientzSettings
{
  public string RabbitMQHost { get; set; } = string.Empty;
  public int RabbitMQPort { get; set; }
  public ClientzHttpSettings Httpz { get; set; } = new ClientzHttpSettings();
}