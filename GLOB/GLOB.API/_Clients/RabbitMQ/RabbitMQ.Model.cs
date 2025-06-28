using RabbitMQ.Client;

namespace GLOB.API.Clientz;

// Supporting types
public class RabbitMQParam
{
    public RabbitMQRoute route { get; set; } = new();
    public RabbitMQOptions options { get; set; } = new();
    public object body { get; set; }
}

public class RabbitMQRoute
{
    public string Exchange { get; set; }
    public string Queue { get; set; }
    public string Key { get; set; }
    public string Typez { get; set; } = ExchangeType.Direct;
}

public class RabbitMQOptions
{
    public bool? AutoAck { get; set; }
    public bool? Mandatory { get; set; }
    public bool? ExchangeDurable { get; set; }
    public bool? ExchangeAutoDelete { get; set; }
    public bool? QueueDurable { get; set; }
    public bool? QueueExclusive { get; set; }
    public bool? QueueAutoDelete { get; set; }
    public IDictionary<string, object> Headers { get; set; }
    public IDictionary<string, object> QueueArguments { get; set; }
}
