using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GLOB.API.Clientz;

// Do not Add in DI
public partial class API_RabbitMQ_Base_Subs : BackgroundService
{
  protected readonly API_RabbitMQ_Base _rmq;
  protected readonly IServiceScopeFactory _scopeFactory;
  public API_RabbitMQ_Base_Subs(IServiceProvider sp, IServiceScopeFactory scopeFactory)
  {
    _scopeFactory = scopeFactory;
    _rmq = sp.GetSrvc<API_RabbitMQ_Base>();
  }
  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    stoppingToken.ThrowIfCancellationRequested();
    return Task.CompletedTask;
  }

  public void BasicConsumeHandler(IModel channel, RabbitMQParam param, EventHandler<BasicDeliverEventArgs> handler)
  {
    var consumer = new EventingBasicConsumer(channel);

    consumer.Received += handler;

    channel.BasicConsume(queue: param.route.Queue ?? "q-default",
                          autoAck: param.options.AutoAck ?? true,
                          consumer: consumer);
  }

  public RabbitMQPayload<T> ToByteType<T>(ReadOnlyMemory<byte>  data)
    where T : class
  {
    try
    {
      var dataz = data.ToArray();
      var msg = Encoding.UTF8.GetString(dataz);
      var model = JsonConvert.DeserializeObject<RabbitMQPayload<T>>(msg);
      return model;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);

      return null;
    }
  }
  // protected override Task ExecuteAsync(CancellationToken stoppingToken)
  // {
  //   stoppingToken.ThrowIfCancellationRequested();
  //   RabbitMQParam param = new()
  //   {
  //     route = new()
  //     {
  //       Exchange = "my-exchange",
  //       Queue = "my-queue",
  //       Key = "my.key"
  //     }
  //   };
  //   var channel = _rmq.SetPubSubDefault(param);

  //   var consumer = new EventingBasicConsumer(channel);
  //   consumer.Received += (_, ea) =>
  //   {
  //     try
  //     {
  //       var body = ea.Body.ToArray();
  //       var message = JsonSerializer.Deserialize<ProjectzLookup>(Encoding.UTF8.GetString(body));
  //       if (message != null)

  //       if (!(param.options.AutoAck ?? true))
  //         channel.BasicAck(ea.DeliveryTag, false);
  //     }
  //     catch (Exception ex)
  //     {
  //       Console.WriteLine($"[Rabbit MQ] Error in message handler: {ex.Message}");
  //       if (!(param.options.AutoAck ?? true))
  //         channel.BasicNack(ea.DeliveryTag, false, requeue: true);
  //     }
  //   };

  //   channel.BasicConsume(queue: param.route.Queue ?? "q-default",
  //                            autoAck: param.options.AutoAck ?? true,
  //                            consumer: consumer);
  //   _rmq.PrintRoute(param, false); 
  //   return Task.CompletedTask;
  // }
}