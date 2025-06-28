using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;

namespace GLOB.API.Clientz;

public partial class API_RabbitMQ : IDisposable
{
  protected readonly IConnection _connection;
  protected readonly IModel _pubChannel;
  protected readonly IModel _subChannel;

  protected readonly IConfiguration _config;
  protected readonly EventProcessor _eventProcessor;
  protected readonly Option_RabbitMQ _option_RabbitMQ;

  public API_RabbitMQ(IServiceProvider sp)
  {
    _config = sp.GetSrvc<IConfiguration>();
    _eventProcessor = sp.GetSrvc<EventProcessor>();
    _option_RabbitMQ = sp.GetSrvc<IOptions<Option_App>>().Value.Clientz.RabbitMQz;
    
    var factory = new ConnectionFactory()
    {
      HostName = _option_RabbitMQ.HostName,
      Port = _option_RabbitMQ.Port
    };
    _connection = factory.CreateConnection();
    _pubChannel = _connection.CreateModel();
    _subChannel = _connection.CreateModel();
   
    
  }
  protected void InitRabbitMQ()
  {
    // var factory = new ConnectionFactory
    // {
    //   Uri = _option_RabbitMQ.Uri,
    //   Port = _option_RabbitMQ.Port,
    //   HostName = _option_RabbitMQ.HostName,
    //   VirtualHost = _option_RabbitMQ.VirtualHost,
    //   UserName = _option_RabbitMQ.UserName,
    //   Password = _option_RabbitMQ.Password
    // };
  }
  
  protected void SetPubSubDefault(IModel channel, RabbitMQParam param)
  {
    if(param.route == null) param.route = new();
    if(param.options == null) param.options = new();

    var exchange = param.route.Exchange ?? "ex-default";
    var queue = param.route.Queue ?? "q-default";
    var routingKey = param.route.Key ?? "k-default";

    channel.ExchangeDeclare(
        exchange: exchange,
        type: param.route.Typez ?? ExchangeType.Direct,
        durable: param.options.ExchangeDurable ?? true,
        autoDelete: param.options.ExchangeAutoDelete ?? false
    );

    channel.QueueDeclare(
        queue: queue,
        durable: param.options.QueueDurable ?? true,
        exclusive: param.options.QueueExclusive ?? false,
        autoDelete: param.options.QueueAutoDelete ?? false,
        arguments: param.options.QueueArguments
    );

    channel.QueueBind(queue, exchange, routingKey);
    
    _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
    Console.WriteLine("--> API_RabbitMQ Connected Successfully.");
  }

  protected void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
  {
    Console.WriteLine("--> API_RabbitMQ connection was shut down.");
  }

  public void Dispose()
  {
    Console.WriteLine("--> API_RabbitMQ connection was shut down.");
    if (_subChannel != null && _subChannel.IsOpen)
    {
      _subChannel.Close();
      _subChannel.Dispose();
    }

    if (_pubChannel != null && _pubChannel.IsOpen)
    {
      _pubChannel.Close();
      _pubChannel.Dispose();
    }

    if (_connection != null && _connection.IsOpen)
    {
      _connection.Close();
      _connection.Dispose();
    }
  }
}