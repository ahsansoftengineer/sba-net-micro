using GLOB.API.Clientz;
namespace SBA.Projectz.Clientz;

public partial class Projectz_RabbitMQ : API_RabbitMQ
{
  public Projectz_RabbitMQ(IServiceProvider sp) : base(sp)
  {
  }
  public void PubsAuth(RabbitMQParam param)
  {
    param.route ??= new();
    param.route.Exchange = "auth";
    Pubs(param);
  }
}