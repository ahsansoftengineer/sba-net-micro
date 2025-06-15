using System.Text;
using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GLOB.API.Clientz;

public class MessageBusSubscriber : BackgroundService
{
  private readonly IConfiguration _config;
  private readonly EventProcessor _eventProcessor;
  private readonly AppSettings _appSettings;
  private IConnection _connection;
  private IModel _channel;
  private string _queueName;

  public MessageBusSubscriber(IServiceProvider sp)
  {
    _config = sp.GetSrvc<IConfiguration>();
    _eventProcessor = sp.GetSrvc<EventProcessor>();
    _appSettings = sp.GetSrvc<IOptions<AppSettings>>().Value;
  }

  private void InitRabbitMQ()
  {
    var factory = new ConnectionFactory()
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

    _queueName = _channel.QueueDeclare().QueueName;

    _channel.QueueBind(
      queue: _queueName,
      exchange: "trigger",
      routingKey: ""
    );
    _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

    Console.WriteLine("--> Listening on the Message Bus...");


  }

  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    stoppingToken.ThrowIfCancellationRequested();
    var consumer = new EventingBasicConsumer(_channel);
    consumer.Received += (ModuleHandle, ea) =>
    {
      Console.WriteLine("--> Message Recieved");
      var body = ea.Body;
      var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

      _eventProcessor.ProcessEvent(notificationMessage);

    };
    _channel.BasicConsume(
      queue: _queueName,
      autoAck: true,
      consumer: consumer
    );
    return Task.CompletedTask;
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