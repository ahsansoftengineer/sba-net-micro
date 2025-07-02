using GLOB.API.Clientz;
using GLOB.API.Config.Configz;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace GLOB.API.DI;

public static partial class DI_API
{
  public static void Add_API_RabbitMQ(this IServiceCollection srvc, IConfiguration config)
  {
    // srvc.AddSingleton<API_RabbitMQ>(); // Singleton
    srvc.AddSingleton<IConnection>(sp =>
    {
        var option = sp.GetRequiredService<IOptions<Option_App>>().Value.Clientz.RabbitMQz;
        var factory = new ConnectionFactory
        {
            HostName = option.HostName,
            Port = option.Port,
            // other options
        };
        return factory.CreateConnection();
    });

    srvc.AddSingleton<IModel>(sp =>
    {
        var connection = sp.GetRequiredService<IConnection>();
        return connection.CreateModel(); // You can register a second IModel for subscriber too
    });
  }
}