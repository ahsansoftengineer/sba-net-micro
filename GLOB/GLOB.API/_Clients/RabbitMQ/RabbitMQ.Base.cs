using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;

namespace GLOB.API.Clientz;

public partial class API_RabbitMQ : IDisposable
{
  protected readonly IConnection _connection;
  protected readonly IModel _pubChannel;
  protected readonly IModel _subChannel;

  protected readonly IConfiguration _config;
  protected readonly EventProcessor _eventProcessor;
  protected readonly Option_RabbitMQ _option_RabbitMQ;

  public API_RabbitMQ(IServiceProvider sp)
  {
    _config = sp.GetSrvc<IConfiguration>();
    _eventProcessor = sp.GetSrvc<EventProcessor>();
    _option_RabbitMQ = sp.GetSrvc<IOptions<Option_App>>().Value.Clientz.RabbitMQz;
    
    var factory = new ConnectionFactory()
    {
      HostName = _option_RabbitMQ.HostName,
      Port = _option_RabbitMQ.Port
    };
    _connection = factory.CreateConnection();
    _pubChannel = _connection.CreateModel();
    _subChannel = _connection.CreateModel();
   
    
  }
  protected void InitRabbitMQ()
  {
    // var factory = new ConnectionFactory
    // {
    //   Uri = _option_RabbitMQ.Uri,
    //   Port = _option_RabbitMQ.Port,
    //   HostName = _option_RabbitMQ.HostName,
    //   VirtualHost = _option_RabbitMQ.VirtualHost,
    //   UserName = _option_RabbitMQ.UserName,
    //   Password = _option_RabbitMQ.Password
    // };
  }
  
  protected void SetPubSubDefault(IModel channel, RabbitMQParam param)
  {
    param.route ??= new();
    param.options ??= new();

    var Route = param.route;
    var Option = param.options;

    channel.ExchangeDeclare(
        exchange: Route.Exchange ??= "ex-default",
        type: Route.Typez ??= ExchangeType.Direct,
        durable: Option.ExchangeDurable ??= true,
        autoDelete: Option.ExchangeAutoDelete ??= false
    );

    channel.QueueDeclare(
        queue: Route.Queue ??= "q-default",
        durable: Option.QueueDurable ??= true,
        exclusive: Option.QueueExclusive ??= false,
        autoDelete: Option.QueueAutoDelete ??= false,
        arguments: Option.QueueArguments
    );

    channel.QueueBind(Route.Queue, Route.Exchange, Route.Key ??= "k-default");
    
    _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
    Console.WriteLine("--> API_RabbitMQ Connected Successfully.");
  }

  protected void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
  {
    Console.WriteLine("--> API_RabbitMQ connection was shut down.");
  }

  public void Dispose()
  {
    Console.WriteLine("--> API_RabbitMQ connection was shut down.");
    if (_subChannel != null && _subChannel.IsOpen)
    {
      _subChannel.Close();
      _subChannel.Dispose();
    }

    if (_pubChannel != null && _pubChannel.IsOpen)
    {
      _pubChannel.Close();
      _pubChannel.Dispose();
    }

    if (_connection != null && _connection.IsOpen)
    {
      _connection.Close();
      _connection.Dispose();
    }
  }
}

// Is it Ok to Three Connection Shuts Down as per Application
// When Application Terminates
// dotnet watch 🛑 Shutdown requested. Press Ctrl+C again to force exit.
// --> API_RabbitMQ connection was shut down.
// --> API_RabbitMQ connection was shut down.
// --> API_RabbitMQ connection was shut down.