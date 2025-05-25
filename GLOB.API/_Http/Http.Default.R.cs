namespace GLOB.API.Http;

public partial class Httpz
{
  public async Task<T?> Get<T>(HttpReq req)
  {
    req.Action = EP.Get;
    return  await Client.Get<T?>(req);
  }
  public async Task<T?> Gets<T>(HttpReq req)
  {
    req.Action = EP.Gets;
    return  await Client.Get<T?>(req);
  }
  public async Task<T?> GetsLookup<T>(HttpReq req)
  {
    req.Action = EP.GetsLookup;
    return  await Client.Get<T?>(req);
  }
  public async Task<T?> GetsByIds<T>(HttpReq req)
  {
    req.Action = EP.GetsByIds;
    return  await Client.Get<T?>(req);
  }
  public async Task<T?> GetsByIdsLookup<T>(HttpReq req)
  {
    req.Action = EP.GetsByIdsLookup;
    return  await Client.Get<T?>(req);
  }
  public async Task<T?> GetsPaginate<T>(HttpReq req)
  {
    req.Action = EP.GetsPaginate;
    return  await Client.Get<T?>(req);
  }
  public async Task<T?> GetsPaginateOptions<T>(HttpReq req)
  {
    req.Action = EP.GetsPaginateOptions;
    return  await Client.Get<T?>(req);
  }

}






