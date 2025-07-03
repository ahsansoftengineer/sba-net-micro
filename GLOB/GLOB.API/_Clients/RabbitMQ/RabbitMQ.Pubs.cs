using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GLOB.API.Clientz;

public partial class API_RabbitMQ
{
  public void Pubs(RabbitMQParam param)
  {
    var channel = SetPubSubDefault(param);

    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(param.payload));
    var props = channel.CreateBasicProperties();
    props.ContentType = "application/json";

    if (param.options.Headers != null)
    {
      props.Headers = param.options.Headers;
    }

    channel.BasicPublish(param.route.Exchange, param.route.Key, param.options.Mandatory ?? false, props, body);

    PrintRoute(param, true);
  }
}