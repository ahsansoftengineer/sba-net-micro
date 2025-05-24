namespace GLOB.API.Http;

public partial class Httpz
{
  protected readonly HttpBase _httpBase;

  public Httpz(IServiceCollection srvcs, string host, string srvc, string controller)
  {
    _httpBase = new HttpBase(new HttpClient(), host, srvc, controller);
  }

  public async Task<T?> Post<T>(HttpReq req)
  {
    return await _httpBase.Post<T>(req);
  }

  public async Task<T?> Patch<T>(HttpReq req)
  {
    return await _httpBase.Patch<T>(req);
  }

  public async Task<T?> Put<T>(HttpReq req)
  {
    return await _httpBase.Put<T>(req);
  }

  public async Task<bool> Delete(HttpReq req)
  {
    return await _httpBase.Delete(req);
  }
}






