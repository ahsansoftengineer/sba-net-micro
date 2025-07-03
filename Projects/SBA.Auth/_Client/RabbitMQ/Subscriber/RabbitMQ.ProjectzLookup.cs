using GLOB.Infra.Model.Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GLOB.API.Clientz;

public partial class RabbitMQ_ProjectzLookup : API_RabbitMQ_Base_Subs
{
  public RabbitMQ_ProjectzLookup(IServiceProvider sp): base(sp)
  {
  }
  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    stoppingToken.ThrowIfCancellationRequested();
    RabbitMQParam param = new()
    {
      route = new()
      {
        Exchange = "my-exchange",
        Queue = "my-queue",
        Key = "my.key"
      }
    };
    var channel = _rmq.SetPubSubDefault(param);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (_, ea) =>
    {
      try
      {
        var body = ea.Body.ToArray();
        var message = JsonSerializer.Deserialize<ProjectzLookup>(Encoding.UTF8.GetString(body));
        if (message != null)

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
    _rmq.PrintRoute(param, false); 
    return Task.CompletedTask;
  }
}