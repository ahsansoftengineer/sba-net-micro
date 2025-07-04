using GLOB.API.Clientz;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace GLOB.API.DI;

public static partial class DI_API
{
  public static void Add_API_RabbitMQ(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.AddSingleton<ConnectionFactory>(sp =>
    {
      var option = sp.GetSrvc<IOptions<Option_App>>().Value.Clientz.RabbitMQz;
      var factory = new ConnectionFactory
      {
        HostName = option.HostName,
        Port = option.Port,
        // Uri = _option_RabbitMQ.Uri,
        // VirtualHost = _option_RabbitMQ.VirtualHost,
        // UserName = _option_RabbitMQ.UserName,
        // Password = _option_RabbitMQ.Password
      };
      return factory;
    });

    srvc.AddSingleton<IConnection>(sp =>
    {
      var factory = sp.GetSrvc<ConnectionFactory>();
      IConnection conn = factory.CreateConnection();
      conn.ConnectionShutdown += (_, e) =>
      {
          Console.WriteLine("--> [Rabbit MQ] Singleton connection shutdown: " + e.ReplyText);
      };
      return conn;
    });

    srvc.AddSingleton<ChannelManager>();
    srvc.AddSingleton<API_RabbitMQ_Base>();
    srvc.AddSingleton<API_RabbitMQ_Base_Pubs>();
    // srvc.AddSingleton<API_RabbitMQ_Base_Subs>();
  }
}