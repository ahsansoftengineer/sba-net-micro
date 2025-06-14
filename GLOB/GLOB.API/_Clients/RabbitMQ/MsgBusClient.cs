using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace GLOB.API.Clientz;

public class RabbitMQ_XYZ : IDisposable
{
  private readonly AppSettings _appSettings;
  private IConnection _connection;
  private IModel _channel;

  public RabbitMQ_XYZ(IServiceProvider sp)
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

  public void Publish(object data)
  {
    try
    {
      // var options = new JsonSerializerOptions
      // {
      //   ReferenceHandler = ReferenceHandler.IgnoreCycles,
      //   WriteIndented = false
      // };

      // var message = JsonSerializer.Serialize(data, options); // line 61
      var message = JsonConvert.SerializeObject(data); // line 61
      if (_connection.IsOpen)
      {
        Console.WriteLine("--> RabbitMQ Connection Open, sending message...");
        SendMessage(message);
      }
      else
      {
        Console.WriteLine("--> RabbitMQ Connection Close, not sending");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Serialization failed: {ex.Message}");
      Console.WriteLine(ex.StackTrace);
    }


  }
  private void SendMessage(string message)
  {
    var body = Encoding.UTF8.GetBytes(message);
    _channel.BasicPublish(
      exchange: "trigger",
      routingKey: "",
      basicProperties: null,
      body
    );
    Console.WriteLine($"--> We have send: {message}");
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
