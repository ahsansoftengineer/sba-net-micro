using GLOB.API.Clientz;
using RabbitMQ.Client;

namespace SBA.Projectz.Clientz;

public partial class RabbitMQ_ProjectzLookup : API_RabbitMQ_Base_Subs
{
  public RabbitMQ_ProjectzLookup(IServiceProvider sp, IServiceScopeFactory sf) : base(sp, sf)
  {
  }
  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    stoppingToken.ThrowIfCancellationRequested();
    var param = new RabbitMQParam
    {
      route = new RabbitMQRoute(MQ_Exch.Auth, Controllerz.Auth.ProjectzLookup)
      {
        Typez = ExchangeType.Direct,
        Key = EP.Add
      }
    };

    var channel = _rmq.SetPubSubDefault(param);

    BasicConsumeHandler(channel, param, async (_, ea) =>
    {
      
      var vm = ToByteToClass<RabbitMQPayload<ProjectzLookup>>(ea.Body);
      await ProcessEvent(vm);
      _rmq.PrintRoute(param, false);
    });

    return Task.CompletedTask;
  }

  private async Task ProcessEvent(RabbitMQPayload<ProjectzLookup> model)
  {
    try
    {
      using var scope = _scopeFactory.CreateScope();
      using var uow = scope.ServiceProvider.GetRequiredService<IUOW_Projectz>();

      if (uow.ProjectzLookupBases.AnyId(model.Body?.ProjectzLookupBaseId ?? 0))
      {
        await uow.ProjectzLookups.Add(model.Body);
        await uow.Save();
        "ProjectzLookup Created Successfully".Print();
      }
      else
      {
        "ProjectzLookupBaseId Does not Exsist".Print();
      }

    }
    catch (Exception ex)
    {
      ex.Print();
    }
  }
}