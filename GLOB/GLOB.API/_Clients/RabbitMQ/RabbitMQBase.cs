using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GLOB.API.Clientz;

public class RabbitBase
{
  private readonly IConnection _connection;
  private readonly IModel _channel;

  public RabbitBase(string hostName = "localhost", string virtualHost = "/", string user = "guest", string password = "guest")
  {
    var factory = new ConnectionFactory
    {
      HostName = hostName,
      VirtualHost = virtualHost,
      UserName = user,
      Password = password
    };

    _connection = factory.CreateConnection();
    _channel = _connection.CreateModel();
  }
  
  public RabbitMQParam Pubs(RabbitMQParam param)
  {
    SetPubSubDefault(param);

    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(param.body));
    _channel.BasicPublish(param.route.Exchange, param.route.Key, body: body);
    return param;

  }

  public void Subs<T>(RabbitMQParam param, Action<T> handler)
  {
    SetPubSubDefault(param);

    var consumer = new EventingBasicConsumer(_channel);
    consumer.Received += (_, ea) =>
    {
      var body = ea.Body.ToArray();
      var message = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(body));
      if (message != null)
        handler(message);
    };

    _channel.BasicConsume(queue: param.route.Queue ?? "q-default", autoAck: param.options.AutoAck ?? true, consumer: consumer);
  }
  public void SetPubSubDefault(RabbitMQParam param)
  {
    // Declare Exchange
    _channel.ExchangeDeclare(
     exchange: param.route.Exchange ?? "ex-default",
     type: param.route.Typez ?? ExchangeType.Direct,
     durable: param.options.ExchangeDurable ?? true,
     autoDelete: param.options.AutoAck ?? true
   );

    // Declare Queue
    _channel.QueueDeclare(
      queue: param.route.Queue ?? "q-default",
      durable: param.options.QueueDurable ?? true,
      exclusive: param.options.QueueExclusive ?? true,
      autoDelete: param.options.ExchangeAutoDelete ?? true
    );

    // Bind Exchange, Queue, Route
    _channel.QueueBind(param.route.Queue ?? "q-default", param.route.Exchange ?? "ex-default", param.route.Key ?? "k-default");
    
  }
}
