using System.Text;
using System.Text.Json;
using GLOB.API.Config.Extz;

namespace GLOB.API.Clientz;

public partial class API_RabbitMQ_Base_Pubs
{
  public readonly API_RabbitMQ_Base _rmq;
  public API_RabbitMQ_Base_Pubs(IServiceProvider sp)
  {
    _rmq = sp.GetSrvc<API_RabbitMQ_Base>();
  }

  public void Pubs(RabbitMQParam param)
  {
    try
    {
      var channel = _rmq.SetPubSubDefault(param);

      Console.WriteLine("--> [Rabbit MQ] Serializing Object");
      var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(param.payload));
      var props = channel.CreateBasicProperties();
      props.ContentType = "application/json";

      if (param.options.Headers != null)
      {
        Console.WriteLine("--> [Rabbit MQ] Settings Headers");
        props.Headers = param.options.Headers;
      }

      if (!_rmq._connection.IsOpen)
        Console.WriteLine("--> [Rabbit MQ] Connection Close, not sending");
      else
      {
        Console.WriteLine("--> [Rabbit MQ] Connection Open, sending message...");
        channel.BasicPublish(param.route.Exchange, param.route.Key, param.options.Mandatory ?? false, props, body);
        _rmq.PrintRoute(param, true);
      }

    }
    catch (Exception ex)
    {
      Console.WriteLine($"[Rabbit MQ] Serialization failed: {ex.Message}");
      Console.WriteLine(ex.StackTrace);
    }
  }
}