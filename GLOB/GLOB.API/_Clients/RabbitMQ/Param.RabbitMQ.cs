
namespace GLOB.API.Clientz;

public static class API_MQ_Param
{
  public static RabbitMQRoute Auth_Lookup => new(MQ_Exch.Auth, Controllerz.ProjectzLookup); 
}