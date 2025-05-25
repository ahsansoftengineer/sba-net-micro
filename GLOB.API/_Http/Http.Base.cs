using System.Text.Json;
using System.Text.Json.Serialization;

namespace GLOB.API.Http;

public class HttpBase
{
  protected readonly string? _host;
  protected readonly string? _srvc;
  protected readonly string? _controller;

  protected readonly HttpClient _httpClient;

  public HttpBase(HttpClient httpClient, string host, string srvc, string controller)
  {
    _httpClient = httpClient;
    _host = host;
    _srvc = srvc;
    _controller = controller;
  }
  public async Task<T?> Get<T>(HttpReq req)
  {
    setDefault(req);
    var response = await _httpClient.GetAsync(req.Url);
    var result =  await DeserializeResponse<T>(response);

    return result;
  }

  public async Task<T?> Post<T>(HttpReq req)
  {
    setDefault(req);
    var response = await _httpClient.PostAsJsonAsync(req.Url, req.Body);
    return await DeserializeResponse<T>(response);
  }

  public async Task<T?> Patch<T>(HttpReq req)
  {
    setDefault(req);
    var response = await _httpClient.PatchAsJsonAsync(req.Url, req.Body);
    return await DeserializeResponse<T>(response);
  }

  public async Task<T?> Put<T>(HttpReq req)
  {
    setDefault(req);
    var response = await _httpClient.PutAsJsonAsync(req.Url, req.Body);
    return await DeserializeResponse<T>(response);
  }

  public async Task<bool> Delete(HttpReq req)
  {
    setDefault(req);
    var response = await _httpClient.DeleteAsync(req.Url);
    return response.IsSuccessStatusCode;
  }

  private HttpReq setDefault(HttpReq req)
  {

    if (string.IsNullOrEmpty(req?.Host))
      req.Host = _host ?? "no-host";

    if (string.IsNullOrEmpty(req?.Srvc))
      req.Srvc = _srvc ?? "no-service";
    
    if (string.IsNullOrEmpty(req?.Controller))
      req.Controller = _controller ?? "no-controller";

    string action = append(req.Action);
    string res = append(req.Resource);    
    
    var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
    
    if(req.Query != null)
    {
      foreach (var prop in req.Query.GetType().GetProperties())
      {
        var value = prop.GetValue(req.Query)?.ToString();
        if (!string.IsNullOrWhiteSpace(value))
          query[prop.Name] = value;
      }
    }


    string queryString = query.HasKeys() ? $"?{query}" : "";

    req.Url = $"{req.Host}/{req.Srvc}/{req.Controller}{action}{res}{queryString}";

    return req;
  }
  private string append(string? value)
  {
    return string.IsNullOrEmpty(value) ? "" : $"/{value}";
  }

  private static async Task<T?> DeserializeResponse<T>(HttpResponseMessage response)
  {
    if (!response.IsSuccessStatusCode)
    {
      var content = await response.Content.ReadAsStringAsync();
      throw new HttpRequestException($"Status: {response.StatusCode}, Content: {content}");
    }

    var result = await response.Content.ReadFromJsonAsync<T>(new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true,
      Converters = { new JsonStringEnumConverter() }
    });

    return result;
  }
}

public record HttpReq
{
  public string? Host { get; set; } // http://www.arab.com || environment.API_req
  public string? Srvc { get; set; } // api/Hierarchy/v1 || environment.API_req
  public string? Controller { get; set; } // employee || environment.API_req
  public string Action { get; set; } // get, gets, get-by-id
  public string? Resource { get; set; } //// get-by-id/1

  public object? Query { get; set; } // {id:1, name:Muhammad}
  // public string? Param { get; set; } // ?id=1&name=Muhammad

  public string? Url {get; set;}

  public object? Body { get; set; } // Specific to CREATE, PATCH, DELETE
}
