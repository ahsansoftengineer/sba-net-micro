
using RabbitMQ.Client;

namespace GLOB.API.Clientz;

public class RabbitMQParam
{
  public RabbitMQRoute? route { get; set; }
  public RabbitMQOption options { get; set; }
  public object body { get;  set; }
}
public class RabbitMQRoute
{
  public string? Exchange { get; set; }
  public string Typez { get; set; } = ExchangeType.Direct;
  public string? Queue { get; set; }
  public string? Key { get; set; }

}
public class RabbitMQOption
{
  // Config
  public bool Durable { get; set; } = true;
  public bool AutoDelete { get; set; } = false;

  // Queue
  public bool QueueDurable { get; set; } = true;
  public bool QueueExclusive { get; set; } = false;
  public bool QueueAutoDelete { get; set; } = false;

  // Consumer
  public bool AutoAck { get; set; } = true;
}
