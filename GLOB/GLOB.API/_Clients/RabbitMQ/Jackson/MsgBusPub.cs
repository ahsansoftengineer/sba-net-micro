using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;

namespace GLOB.API.Clientz;
public class MsgBusPub : IDisposable
{
  protected readonly Option_RabbitMQ _option_RabbitMQ;
  protected IConnection _connection;
  protected IModel _channel;
  public MsgBusPub(IServiceProvider sp)
  {
    _option_RabbitMQ = sp.GetSrvc<IOptions<Option_App>>().Value.Clientz.RabbitMQz;
    Init();
  }  
  public void Publish(object data)
  {
    try
    {
      var message = JsonConvert.SerializeObject(data);
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


  public void Init()
  {
    var factory = new ConnectionFactory
    {
      HostName = _option_RabbitMQ.HostName,
      Port = _option_RabbitMQ.Port
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
      Console.WriteLine($"--> Connection Msg Bus Failed{ex.Message}");
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