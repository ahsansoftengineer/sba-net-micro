using GLOB.API.Clientz;
using GLOB.API.Config.Extz;
using GLOB.Infra.Model.Base;
namespace SBA.Projectz.Clientz;

public class RabbitMQ_Subs_ProjectzLookup
{
  public RabbitMQRoute Route = null;
  private readonly API_RabbitMQ _rmq;
  public RabbitMQ_Subs_ProjectzLookup(IServiceProvider sp)
  {
    _rmq = sp.GetSrvc<API_RabbitMQ>();
    Route = new RabbitMQRoute(MQ_Exch.Auth, Controllerz.Auth.ProjectzLookup);
  }
  public void SubsAuth_Create(RabbitMQParam param)
  {
    param.route ??= new();
    param.route.Exchange = "auth";
    _rmq.Subs<ProjectzLookup>(param, _ =>
    {

    });
  }
}