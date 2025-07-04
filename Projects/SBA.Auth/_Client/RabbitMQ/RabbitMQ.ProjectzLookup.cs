using GLOB.API.Clientz;
using GLOB.Infra.Model.Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SBA.Projectz.Data;
using System.Text;
using System.Text.Json;

namespace SBA.Projectz.Clientz;

public partial class RabbitMQ_ProjectzLookup : API_RabbitMQ_Base_Subs
{
  private readonly EventProjectzLookupCreate _eventProcessor;
  public RabbitMQ_ProjectzLookup(IServiceProvider sp, IServiceScopeFactory sf) : base(sp, sf)
  {
    _eventProcessor = sp.GetSrvc<EventProjectzLookupCreate>();
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
      Console.WriteLine("--> [Rabbit MQ] Message Recieved");
      var body = ea.Body;
      var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

      _eventProcessor.ProcessEvent(notificationMessage);
    };

    channel.BasicConsume(queue: param.route.Queue ?? "q-default",
                          autoAck: param.options.AutoAck ?? true,
                          consumer: consumer);
    _rmq.PrintRoute(param, false); 

    return Task.CompletedTask;
  }
}