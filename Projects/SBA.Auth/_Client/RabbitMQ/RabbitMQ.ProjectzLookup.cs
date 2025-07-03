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
  // protected readonly IUOW_Projectz _uowProjectz;
   private readonly IServiceScopeFactory _scopeFactory;
  public RabbitMQ_ProjectzLookup(IServiceProvider sp) : base(sp)
  {
    _scopeFactory = sp.GetSrvc<IServiceScopeFactory>();
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
        Console.WriteLine(Encoding.UTF8.GetString(body));

        var message = JsonSerializer.Deserialize<RabbitMQPayload<ProjectzLookup>>(Encoding.UTF8.GetString(body));
        if (message != null)
        {
          var dto = message.Body;

          using var scope = _scopeFactory.CreateScope();
          var _uowProjectz = scope.ServiceProvider.GetRequiredService<IUOW_Projectz>();
          _uowProjectz.ProjectzLookups.Insert(new()
          {
            Name = dto.Name,
            ProjectzLookupBaseId = dto.ProjectzLookupBaseId,
            Code = dto.Code,
            Desc = dto.Desc,
          });
          _uowProjectz.Save();
          
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