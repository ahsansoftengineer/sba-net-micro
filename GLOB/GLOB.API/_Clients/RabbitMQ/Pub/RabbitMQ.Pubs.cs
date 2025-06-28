using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GLOB.API.Clientz;

public partial class API_RabbitMQ : IDisposable
{
  public void Pubs(RabbitMQParam param)
  {
    SetPubSubDefault(_pubChannel, param);

    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(param.body));
    var props = _pubChannel.CreateBasicProperties();
    props.ContentType = "application/json";

    if (param.options.Headers != null)
    {
      props.Headers = param.options.Headers;
    }

    _pubChannel.BasicPublish(param.route.Exchange, param.route.Key, param.options.Mandatory ?? false, props, body);
  }
}