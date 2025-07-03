using RabbitMQ.Client;
using GLOB.API.Config.Extz;
using System.Collections.Concurrent;

namespace GLOB.API.Clientz;

public partial class API_RabbitMQ : IDisposable
{
  protected readonly IConnection _connection;
  protected readonly ChannelManager _channelMngr;
  protected readonly ConcurrentDictionary<string, IModel> _channels = new();

  protected readonly EventProcessor _eventProcessor;

  public API_RabbitMQ(IServiceProvider sp)
  {
    _connection = sp.GetSrvc<IConnection>();
    _channelMngr = sp.GetSrvc<ChannelManager>();
    _eventProcessor = sp.GetSrvc<EventProcessor>();
  }

  protected IModel SetPubSubDefault(RabbitMQParam param)
  {
    // IModel channel = _channelManager.GetOrCreateChannel($"pub:{param.route.Exchange}:{param.route.Key}");
    IModel channel = _channelMngr.GetOrCreateChannel($"{param.route.Exchange}:{param.route.Key}");

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
    string? queue = $"{Route.Exchange}_{Route.Queue ??= "q-default"}";

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
    return channel;
  }

  protected void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
  {
    Console.WriteLine("--> API_RabbitMQ connection was shut down.");
  }

  public void Dispose()
  {
    Console.WriteLine("--> API_RabbitMQ connection was shut down.");
    if (_connection != null && _connection.IsOpen)
    {
      _connection.Close();
      _connection.Dispose();
    }
  }
}