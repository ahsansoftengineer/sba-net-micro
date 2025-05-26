namespace GLOB.API.Http;

public partial class Httpz
{
  public async Task<T?> Get<T>(HttpReq req)
  {
    req.Action = EP.Get;
    return  await Client.Post<T?>(req);
  }
  public async Task<T?> Gets<T>(HttpReq req)
  {
    req.Action = EP.Gets;
    return  await Client.Post<T?>(req);
  }
  public async Task<T?> GetsLookup<T>(HttpReq req)
  {
    req.Action = EP.GetsLookup;
    return  await Client.Get<T?>(req);
  }
  public async Task<T?> GetsByIds<T>(HttpReq req)
  {
    req.Action = EP.GetsByIds;
    return  await Client.Post<T?>(req);
  }
  public async Task<T?> GetsByIdsLookup<T>(HttpReq req)
  {
    req.Action = EP.GetsByIdsLookup;
    return  await Client.Post<T?>(req);
  }
  public async Task<T?> GetsPaginate<T>(HttpReq req)
  {
    req.Action = EP.GetsPaginate;
    return  await Client.Post<T?>(req);
  }
  public async Task<T?> GetsPaginateOptions<T>(HttpReq req)
  {
    req.Action = EP.GetsPaginateOptions;
    return  await Client.Post<T?>(req);
  }

}
// public async Task<IActionResult> Gets()
// {
//   var result = await AuthLookupBaseHttpz.Gets<ResponseRecords<ProjectzLookup>>(new () {
//     Action =  EP.Gets,
//     Body =  new { includes = new List<string>() { "ProjectzLookupBase"} }
//   });
//   var resultz =  result.Records;
//   return resultz.Ok();
// }





