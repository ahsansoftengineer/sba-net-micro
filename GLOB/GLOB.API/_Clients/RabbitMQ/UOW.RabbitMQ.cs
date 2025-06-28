// // Need to Work on That Service for Always

// using GLOB.API.Config.Configz;
// using GLOB.API.Config.Extz;
// using Microsoft.Extensions.Options;

// namespace GLOB.API.Clientz;

// public partial class UOW_API_RabbitMQ
// {
//   private readonly Option_RabbitMQ _Option_RabbitMQz;
//   private API_Httpz _API_Httpz_AuthLookup;

//   public UOW_API_RabbitMQ(IServiceProvider sp)
//   {
//     _Option_RabbitMQz = sp.GetSrvc<IOptions<Option_App>>().Value.Clientz.RabbitMQz;
//   }

//   public API_Httpz API_Httpz_AuthLookup => _API_Httpz_AuthLookup = new API_RabbitMQ(_sp) ;
// }