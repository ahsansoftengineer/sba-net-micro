using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace GLOB.API.Clientz;
public class RabbitMQ_Base : IDisposable
{
  protected readonly AppSettings _appSettings;
  protected IConnection _connection;
  protected IModel _channel;

  public RabbitMQ_Base(IServiceProvider sp)
  {
    _appSettings = sp.GetSrvc<IOptions<AppSettings>>().Value;
    Init();
  }

  public void Init()
  {
    string HostName = _appSettings.Clientz.RabbitMQHost;
    int Port = _appSettings.Clientz.RabbitMQPort;
    var factory = new ConnectionFactory
    {
      HostName = HostName,
      Port = Port
    };
    try
    {
      _connection = factory.CreateConnection();
      _channel = _connection.CreateModel();

      _channel.ExchangeDeclare(
          exchange: "trigger",
          type: ExchangeType.Fanout
      );
      _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
      Console.WriteLine("--> Connection Msg Bus Successfull");
    }
    catch (Exception ex)
    {
      Console.WriteLine("--> Connection Msg Bus Failed");

    }
  }

  private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
  {
    Console.WriteLine("--> RabbitMQ connection was shut down.");
  }
  
  public void Dispose()
  {
    if (_channel != null && _channel.IsOpen)
    {
      _channel.Close();
      _channel.Dispose();
    }

    if (_connection != null && _connection.IsOpen)
    {
      _connection.Close();
      _connection.Dispose();
    }
  }
}