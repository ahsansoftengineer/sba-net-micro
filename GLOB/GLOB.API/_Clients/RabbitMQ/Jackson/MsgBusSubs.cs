using System.Text;

using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GLOB.API.Clientz;

public class MsgBusSubs : BackgroundService
{
  private readonly IConfiguration _config;
  private readonly IServiceScopeFactory _scopeFactory;
  private readonly Option_RabbitMQ _option_RabbitMQ;
  private IConnection _connection;
  private IModel _channel;
  private string _queueName;

  public MsgBusSubs(IServiceProvider sp)
  {
    _config = sp.GetSrvc<IConfiguration>();
    _scopeFactory = sp.GetSrvc<IServiceScopeFactory>();
    _option_RabbitMQ = sp.GetSrvc<IOptions<Option_App>>().Value.Clients.RabbitMQz;
    InitRabbitMQ();
  }

  private void InitRabbitMQ()
  {
    var factory = new ConnectionFactory()
    {
      HostName = _option_RabbitMQ.HostName,
      Port = _option_RabbitMQ.Port,
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

    Console.WriteLine("--> [Rabbit MQ] Listening on the Message Bus...");
  }

  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    stoppingToken.ThrowIfCancellationRequested();
    var consumer = new EventingBasicConsumer(_channel);
    consumer.Received += async (ModuleHandle, ea) =>
    {
      Console.WriteLine("--> [Rabbit MQ] Message Recieved");
      var body = ea.Body;
      var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

      await ProcessEvent(notificationMessage);

    };
    _channel.BasicConsume(
      queue: _queueName,
      autoAck: true,
      consumer: consumer
    );
    return Task.CompletedTask;
  }

  public async Task ProcessEvent(string message)
  {
    try
    {
      using var scope = _scopeFactory.CreateScope();
      using var uow = scope.ServiceProvider.GetRequiredService<IUOW_Infra>();
      var model = JsonConvert.DeserializeObject<ProjectzLookup>(message);

      if (uow.ProjectzLookupBases.AnyId(model?.ProjectzLookupBaseId ?? 0))
      {
        await uow.ProjectzLookups.Insert(model);
        await uow.Save();
        Console.WriteLine("ProjectzLookup Created Successfully");
      }
      else
      {
        Console.WriteLine("ProjectzLookupBaseId Does not Exsist");
      }

    }
    catch (Exception ex)
    {
      Console.WriteLine($"--> ProjectzLookup not Created {ex.Message}");
    }
  }

  private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
  {
    Console.WriteLine("--> [Rabbit MQ] connection was shut down. Jackson");
  }
  public override void Dispose()
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
    base.Dispose();
  }
}