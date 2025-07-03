using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GLOB.API.Clientz;

public partial class API_RabbitMQ
{
  public void Subs<T>(RabbitMQParam param, Action<T> handler)
  {
    var channel = SetPubSubDefault(param);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (_, ea) =>
    {
      try
      {
        var body = ea.Body.ToArray();
        var message = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(body));
        if (message != null)
          handler(message);

        if (!(param.options.AutoAck ?? true))
          channel.BasicAck(ea.DeliveryTag, false);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"[RabbitMQ] Error in message handler: {ex.Message}");
        if (!(param.options.AutoAck ?? true))
          channel.BasicNack(ea.DeliveryTag, false, requeue: true);
      }
    };

    channel.BasicConsume(queue: param.route.Queue ?? "q-default",
                             autoAck: param.options.AutoAck ?? true,
                             consumer: consumer);
    PrintRoute(param, false);
  }
}