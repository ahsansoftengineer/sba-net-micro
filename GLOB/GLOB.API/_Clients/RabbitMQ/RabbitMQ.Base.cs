using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;

namespace GLOB.API.Clientz;

public partial class API_RabbitMQ : IDisposable
{
  protected readonly ConnectionFactory _factory;
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

    _factory = sp.GetSrvc<ConnectionFactory>();
    _connection = sp.GetSrvc<IConnection>();;

    // IModel is not thread-safe. Using it for both pub/sub concurrently can cause race
    // One channel for publishing, one for consuming = clear responsibility, easier debugging.
    // Consumers are long-running. Blocking ops on same channel can affect publisher.
    _pubChannel = _connection.CreateModel();
    _subChannel = _connection.CreateModel();
   
    
  }
  
  protected void SetPubSubDefault(IModel channel, RabbitMQParam param)
  {
    param.route ??= new();
    param.options ??= new();

    var Route = param.route;
    var Option = param.options;

    channel.ExchangeDeclare(
      exchange: Route.Exchange ??= "NameExchane",
      type: Route.Typez ??= ExchangeType.Direct,
      durable: Option.ExchangeDurable ??= true,
      autoDelete: Option.ExchangeAutoDelete ??= false
    );
    string? queue = $"{Route.Exchange}_{Route.Queue ??= "q-default"}" ;
    
    channel.QueueDeclare(
      queue: queue ??= "NameQueue",
      durable: Option.QueueDurable ??= true,
      exclusive: Option.QueueExclusive ??= false,
      autoDelete: Option.QueueAutoDelete ??= false,
      arguments: Option.QueueArguments
    );

    channel.QueueBind(Route.Queue, Route.Exchange, Route.Key ??= "NameRoute");
    
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