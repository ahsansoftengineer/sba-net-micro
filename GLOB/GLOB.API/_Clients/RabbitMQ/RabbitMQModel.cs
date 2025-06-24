namespace GLOB.API.Clientz;

public class RabbitMQParam
{
  public RabbitMQRoute? route { get; set; }
  public RabbitMQOption? options { get; set; }
  public object body { get;  set; }
}
public class RabbitMQRoute
{
  public string? Exchange { get; set; }
  public string? Typez { get; set; }
  public string? Queue { get; set; }
  public string? Key { get; set; }

}
public class RabbitMQOption
{
  // Exchange
  public bool? Durable { get; set; }
  public bool? AutoDelete { get; set; }

  // Queue
  public bool? QueueDurable { get; set; }
  public bool? QueueExclusive { get; set; }
  public bool? QueueAutoDelete { get; set; }

  // Consumer
  public bool? AutoAck { get; set; }
}
