using System.Text;
using System.Text.Json;

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

      "Serializing Object".Print("[Rabbit MQ]");
      var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(param.payload));
      var props = channel.CreateBasicProperties();
      props.ContentType = "application/json";

      if (param.options.Headers != null)
      {
        "Settings Headers".Print("[Rabbit MQ]");
        props.Headers = param.options.Headers;
      }

      if (!_rmq._connection.IsOpen)
        "Connection Close, not sending".Print("[Rabbit MQ]");
      else
      {
        "Connection Open, sending message...".Print("[Rabbit MQ]");
        channel.BasicPublish(param.route.Exchange, param.route.Key, param.options.Mandatory ?? false, props, body);
        _rmq.PrintRoute(param, true);
      }

    }
    catch (Exception ex)
    {
      $"[Rabbit MQ] Serialization failed: {ex.Message}".Print("[Rabbit MQ]");
      Console.WriteLine(ex.StackTrace);
    }
  }
}