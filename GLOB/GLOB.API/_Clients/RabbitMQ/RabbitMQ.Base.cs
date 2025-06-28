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
  private readonly IConnection _connection;
  private readonly IModel _pubChannel;
  private readonly IModel _subChannel;

  private readonly IConfiguration _config;
  private readonly EventProcessor _eventProcessor;
  private readonly Option_RabbitMQ _option_RabbitMQ;

  public API_RabbitMQ(IServiceProvider sp)
  {
    _config = sp.GetSrvc<IConfiguration>();
    _eventProcessor = sp.GetSrvc<EventProcessor>();
    _option_RabbitMQ = sp.GetSrvc<IOptions<Option_App>>().Value.Clientz.RabbitMQz;
    // InitRabbitMQ();
    var factory = new ConnectionFactory()
    {
      HostName = _option_RabbitMQ.HostName,
      Port = _option_RabbitMQ.Port
    };
    _connection = factory.CreateConnection();
    _pubChannel = _connection.CreateModel();
    _subChannel = _connection.CreateModel();
    
  }
  private void InitRabbitMQ()
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
  
  private void SetPubSubDefault(IModel channel, RabbitMQParam param)
  {
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
  }

  private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
  {
    Console.WriteLine("--> RabbitMQ connection was shut down.");
  }

  public void Dispose()
  {
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