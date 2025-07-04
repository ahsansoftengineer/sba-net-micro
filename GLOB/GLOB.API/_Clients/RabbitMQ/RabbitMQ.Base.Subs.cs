
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