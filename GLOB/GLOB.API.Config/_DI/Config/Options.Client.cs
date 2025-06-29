namespace GLOB.API.Config.Configz;

public class Option_Http
{
  public string Gateway { get; set; } = string.Empty;
  public string Auth { get; set; } = string.Empty;
  public string Hierarchy { get; set; } = string.Empty;
}

public class Option_RabbitMQ
{
  public string Uri { get; set; } = string.Empty;
  public int Port { get; set; }
  public string HostName { get; set; } = string.Empty;
  public string VirtualHost { get; set; } = string.Empty;
  public string UserName { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
}

public class Option_Clientz
{
  public Option_RabbitMQ RabbitMQz { get; set; }
  public Option_Http Http_Host { get; set; } = new Option_Http();
}


    //   // Uri = "",
    //   // Port = 5672,
    //   HostName = hostName,
    //   VirtualHost = virtualHost,
    //   UserName = user,
    //   Password = password