using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using GLOB.Infra.Model.Base;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GLOB.API.Clientz;

public class MsgBusClient : IAsyncDisposable
{
  private readonly AppSettings _appSettings;
  private IConnection _connection;
  private IModel _channel;

  public MsgBusClient(IServiceProvider sp)
  {
    _appSettings = sp.GetSrvc<IOptions<AppSettings>>().Value;
  }

  public async Task InitializeAsync()
  {
    var factory = new ConnectionFactory
    {
      HostName = _appSettings.Clientz.RabbitMQHost,
      Port = _appSettings.Clientz.RabbitMQPort
    };

    _connection = factory.CreateConnection();
    _channel = _connection.CreateModel();

    _channel.ExchangeDeclare(
        exchange: "trigger",
        type: ExchangeType.Fanout
    );

    _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
  }

  private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
  {
    Console.WriteLine("--> RabbitMQ connection was shut down.");
    throw new NotImplementedException();
  }

  public Task PublishAsync(ProjectzLookupBase data)
  {
    var message = JsonSerializer.Serialize(data);
    var body = Encoding.UTF8.GetBytes(message);

    _channel.BasicPublish(
        exchange: "trigger",
        routingKey: "",
        basicProperties: null,
        body: body
    );

    Console.WriteLine($"--> Message sent: {message}");

    return Task.CompletedTask;
  }

  public async ValueTask DisposeAsync()
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

    await Task.CompletedTask;
  }
}
