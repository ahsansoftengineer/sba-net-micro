using RabbitMQ.Client;
using System.Collections.Concurrent;

namespace GLOB.API.Clientz;

public partial class API_RabbitMQ_Base : IDisposable
{
  public readonly IConnection _connection;
  public readonly ChannelManager _channelMngr;
  public readonly ConcurrentDictionary<string, IModel> _channels = new();

  public API_RabbitMQ_Base(IServiceProvider sp)
  {
    _connection = sp.GetSrvc<IConnection>();
    _channelMngr = sp.GetSrvc<ChannelManager>();
  }

  public IModel SetPubSubDefault(RabbitMQParam param)
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

    channel.QueueDeclare(
      queue: Route.Queue ??= "NameQueue",
      durable: Option.QueueDurable ??= true,
      exclusive: Option.QueueExclusive ??= false,
      autoDelete: Option.QueueAutoDelete ??= false,
      arguments: Option.QueueArguments
    );

    channel.QueueBind(Route.Queue, Route.Exchange, Route.Key ??= "NameRoute");

    $"Connected Successfully. Exchange: {param.route.Exchange} Queue {param.route.Queue}".Print("Rabbit MQ"); 
    return channel;
  }
  public void PrintRoute(RabbitMQParam param, bool isPub)
  {
    ((isPub ? "Publish" : "Subscribe") + " Successfully").Print("Rabbit MQ");
    
    Console.WriteLine("-->\n\t Exchange: {0}\n\t Queue: {1}\n\t Route & Topic: {2}\n\t Headers: {3}\n\t",
                     param.route.Exchange,
                     param.route.Queue,
                     param.route.Key,
                     param.options.Headers
                     );
    Ext.Print();
  }

  public void Dispose()
  {
    if (_connection != null && _connection.IsOpen)
    {
      "Connection Getting Down. (Dispose)".Print("Rabbit MQ");
      _connection.Close();
      _connection.Dispose();
    }
  }
}