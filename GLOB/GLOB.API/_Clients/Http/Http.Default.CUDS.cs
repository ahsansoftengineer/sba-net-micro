using GLOB.API.Staticz;

namespace GLOB.API.Clientz;

public partial class Httpz
{
  public readonly HttpBase Client;

  public Httpz(string host, string srvc, string controller)
  {
    Client = new HttpBase(new HttpClient(), host, srvc, controller);
  }

  public async Task<T?> Create<T>(HttpReq req)
  {
    req.Action = EP.Create;
    return await Client.Post<T>(req);
  }

  public async Task<T?> Status<T>(HttpReq req)
  {
    req.Action = EP.Status;
    return await Client.Patch<T>(req);
  }

  public async Task<T?> Update<T>(HttpReq req)
  {
    req.Action = EP.Update;
    return await Client.Put<T>(req);
  }

  public async Task<object> Delete(HttpReq req)
  {
    req.Action = EP.Delete;
    return await Client.Delete(req);
  }
}
// public readonly Httpz AuthLookupBaseHttpz;
// public AuthLookupBaseHttpController(IServiceProvider srvc): base(srvc) 
// {
//   string  gatewayUrl = _config.GetValueStr("URLzGateway"); 
//   AuthLookupBaseHttpz = new Httpz(gatewayUrl, Srvc.Auth, Controllerz.ProjectzLookup) ;
// }
// [HttpPost]
// public async Task<IActionResult> Gets()
// {
//   // string gatewayUrl = _config.GetValueStr("URLzGateway"); 
//   var result = await AuthLookupBaseHttpz.Gets<ResponseRecords<ProjectzLookup>>(
//     new () {
//       // Host = gatewayUrl,
//       // Srvc = Srvc.Auth,
//       // Controller = Controllerz.Lookup,
//       Action =  EP.Gets,
//       // Resource = "1",
//       // Query = new { Id = 101 },
//       Body =  new {} //new  { includes = new List<string>() { "_projectz-lookupz-base"} }

//     }
//   );
//   var resultz =  result.Records;
//   return resultz.Ok();
// }





