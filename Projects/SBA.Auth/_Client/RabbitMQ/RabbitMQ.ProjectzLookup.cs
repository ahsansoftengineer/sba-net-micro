using GLOB.API.Clientz;
using GLOB.API.Config.Extz;
using GLOB.Infra.Model.Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SBA.Projectz.Data;
using System.Text;
using System.Text.Json;

namespace SBA.Projectz.Clientz;

public partial class RabbitMQ_ProjectzLookup : API_RabbitMQ_Base_Subs
{
  protected readonly IUOW_Projectz _uowProjectz;
  
  public RabbitMQ_ProjectzLookup(IServiceProvider sp) : base(sp)
  {
    _uowProjectz = sp.GetSrvc<IUOW_Projectz>();
  }
  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    stoppingToken.ThrowIfCancellationRequested();
    var param = new RabbitMQParam
    {
      route = new RabbitMQRoute(MQ_Exch.Auth, Controllerz.Auth.ProjectzLookup)
      {
        Typez = ExchangeType.Direct,
        Key = EP.Create
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
        {
          Console.WriteLine(body);
          // _uowProjectz.ProjectzLookups.Insert(message);
          
        }


        if (!(param.options.AutoAck ?? true))
          channel.BasicAck(ea.DeliveryTag, false);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"--> [Rabbit MQ] Error in message handler: {ex.Message}");
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