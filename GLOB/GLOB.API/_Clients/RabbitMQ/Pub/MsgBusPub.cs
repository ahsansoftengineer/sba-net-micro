using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace GLOB.API.Clientz;

public class MsgBusPub : MsgBusBase, IDisposable
{

  public MsgBusPub(IServiceProvider sp): base(sp)
  {
  }
  public void Publish(object data)
  {
    try
    {
      var message = JsonConvert.SerializeObject(data);
      if (_connection.IsOpen)
      {
        Console.WriteLine("--> RabbitMQ Connection Open, sending message...");
        SendMessage(message);
      }
      else
      {
        Console.WriteLine("--> RabbitMQ Connection Close, not sending");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Serialization failed: {ex.Message}");
      Console.WriteLine(ex.StackTrace);
    }


  }
  private void SendMessage(string message)
  {
    var body = Encoding.UTF8.GetBytes(message);
    _channel.BasicPublish(
      exchange: "trigger",
      routingKey: "",
      basicProperties: null,
      body
    );
    Console.WriteLine($"--> We have send: {message}");
  }
}
