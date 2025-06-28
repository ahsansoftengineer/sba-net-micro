namespace GLOB.API.Clientz;

public partial class API_Httpz
{
  public async Task<T?> Get<T>(HttpParam? req = null)
  {
    if (req == null) req = new();
    req.Action = EP.Get;
    return  await Client.Post<T?>(req);
  }
  public async Task<T?> Gets<T>(HttpParam? req = null)
  {
    if (req == null) req = new();
    req.Action = EP.Gets;
    return  await Client.Post<T?>(req);
  }
  public async Task<T?> GetsLookup<T>(HttpParam? req = null)
  {
    if (req == null) req = new();
    req.Action = EP.GetsLookup;
    return  await Client.Get<T?>(req);
  }
  public async Task<T?> GetsByIds<T>(HttpParam? req = null)
  {
    if (req == null) req = new();
    req.Action = EP.GetsByIds;
    return  await Client.Post<T?>(req);
  }
  public async Task<T?> GetsByIdsLookup<T>(HttpParam req)
  {
    req.Action = EP.GetsByIdsLookup;
    return  await Client.Post<T?>(req);
  }
  public async Task<T?> GetsPaginate<T>(HttpParam req)
  {
    req.Action = EP.GetsPaginate;
    return  await Client.Post<T?>(req);
  }
  public async Task<T?> GetsPaginateOptions<T>(HttpParam req)
  {
    req.Action = EP.GetsPaginateOptions;
    return  await Client.Post<T?>(req);
  }

}
// public async Task<IActionResult> Gets()
// {
//   var result = await API_Httpz_AuthLookup.Gets<ResponseRecords<ProjectzLookup>>(new () {
//     Action =  EP.Gets,
//     Body =  new { includes = new List<string>() { "ProjectzLookupBase"} }
//   });
//   var resultz =  result.Records;
//   return resultz.Ok();
// }





