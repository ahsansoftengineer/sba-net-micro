using GLOB.API.Staticz;

namespace GLOB.API.Clientz;

public partial class API_Httpz
{
  public readonly API_HttpBase Client;

  public API_Httpz(string host, string srvc, string controller)
  {
    Client = new API_HttpBase(new HttpClient(), host, srvc, controller);
  }

  public async Task<T?> Create<T>(HttpParam req)
  {
    req.Action = EP.Create;
    return await Client.Post<T>(req);
  }

  public async Task<T?> Status<T>(HttpParam req)
  {
    req.Action = EP.Status;
    return await Client.Patch<T>(req);
  }

  public async Task<T?> Update<T>(HttpParam req)
  {
    req.Action = EP.Update;
    return await Client.Put<T>(req);
  }

  public async Task<object> Delete(HttpParam req)
  {
    req.Action = EP.Delete;
    return await Client.Delete(req);
  }
}
// public readonly API_Httpz API_Httpz_AuthLookup;
// public AuthLookupBaseHttpController(IServiceProvider srvc): base(srvc) 
// {
//   string  gatewayUrl = _config.GetValueStr("URLzGateway"); 
//   API_Httpz_AuthLookup = new API_Httpz(gatewayUrl, Srvc.Auth, Controllerz.ProjectzLookup) ;
// }
// [HttpPost]
// public async Task<IActionResult> Gets()
// {
//   // string gatewayUrl = _config.GetValueStr("URLzGateway"); 
//   var result = await API_Httpz_AuthLookup.Gets<ResponseRecords<ProjectzLookup>>(
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





