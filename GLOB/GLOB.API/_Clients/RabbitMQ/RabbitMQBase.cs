using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GLOB.API.Clientz;

public class RabbitBase : IDisposable
{
  private readonly IConnection _connection;
  private readonly IModel _pubChannel;
  private readonly IModel _subChannel;

  public RabbitBase(string hostName = "localhost", string virtualHost = "/", string user = "guest", string password = "guest")
  {
    var factory = new ConnectionFactory
    {
      // Uri = "",
      // Port = 5672,
      HostName = hostName,
      VirtualHost = virtualHost,
      UserName = user,
      Password = password
    };

    _connection = factory.CreateConnection();
    _pubChannel = _connection.CreateModel();
    _subChannel = _connection.CreateModel();
  }

  public void Pubs(RabbitMQParam param)
  {
    SetPubSubDefault(_pubChannel, param);

    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(param.body));
    var props = _pubChannel.CreateBasicProperties();
    props.ContentType = "application/json";

    if (param.options.Headers != null)
    {
      props.Headers = param.options.Headers;
    }

    _pubChannel.BasicPublish(param.route.Exchange, param.route.Key, param.options.Mandatory ?? false, props, body);
  }

  public void Subs<T>(RabbitMQParam param, Action<T> handler)
  {
    SetPubSubDefault(_subChannel, param);

    var consumer = new EventingBasicConsumer(_subChannel);
    consumer.Received += (_, ea) =>
    {
      try
      {
        var body = ea.Body.ToArray();
        var message = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(body));
        if (message != null)
          handler(message);

        if (!(param.options.AutoAck ?? true))
          _subChannel.BasicAck(ea.DeliveryTag, false);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"[RabbitMQ] Error in message handler: {ex.Message}");
        if (!(param.options.AutoAck ?? true))
          _subChannel.BasicNack(ea.DeliveryTag, false, requeue: true);
      }
    };

    _subChannel.BasicConsume(queue: param.route.Queue ?? "q-default",
                             autoAck: param.options.AutoAck ?? true,
                             consumer: consumer);
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
    base.Dispose();
  }
}