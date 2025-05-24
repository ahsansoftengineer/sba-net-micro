namespace GLOB.API.Http;

public partial class Httpz
{
  public async Task<T?> Get<T>(HttpReq req)
  {
    req.Action = EP.Get;
    return  await _httpBase.Get<T>(req);
  }
  public async Task<List<T>?> Gets<T>(HttpReq req)
  {
    req.Action = EP.Gets;
    return  await _httpBase.Get<List<T>>(req);
  }
  public async Task<List<T>?> GetsLookup<T>(HttpReq req)
  {
    req.Action = EP.GetsLookup;
    return  await _httpBase.Get<List<T>>(req);
  }
  public async Task<List<T>?> GetsByIds<T>(HttpReq req)
  {
    req.Action = EP.GetsByIds;
    return  await _httpBase.Get<List<T>>(req);
  }
  public async Task<List<T>?> GetsByIdsLookup<T>(HttpReq req)
  {
    req.Action = EP.GetsByIdsLookup;
    return  await _httpBase.Get<List<T>>(req);
  }
  public async Task<List<T>?> GetsPaginate<T>(HttpReq req)
  {
    req.Action = EP.GetsPaginate;
    return  await _httpBase.Get<List<T>>(req);
  }
  public async Task<List<T>?> GetsPaginateOptions<T>(HttpReq req)
  {
    req.Action = EP.GetsPaginateOptions;
    return  await _httpBase.Get<List<T>>(req);
  }

}






