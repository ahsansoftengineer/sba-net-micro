namespace GLOB.API.Http;

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

  public async Task<bool> Delete(HttpReq req)
  {
    req.Action = EP.Delete;
    return await Client.Delete(req);
  }
}






