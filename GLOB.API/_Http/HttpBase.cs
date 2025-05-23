namespace GLOB.API.Http;

public class HttpBaseService
{
    private readonly HttpClient _httpClient;

    public HttpBaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<T?> GetAsync<T>(string ep, object? parameters = null)
    {
        var url = BuildUrlWithParams(ep, parameters);
        var response = await _httpClient.GetAsync(url);
        return await DeserializeResponse<T>(response);
    }

    public async Task<List<T>> GetsAsync<T>(string ep, object? parameters = null)
    {
        var url = BuildUrlWithParams(ep, parameters);
        var response = await _httpClient.GetAsync(url);
        return await DeserializeResponse<List<T>>(response) ?? new();
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string ep, TRequest payload)
    {
        var response = await _httpClient.PostAsJsonAsync(ep, payload);
        return await DeserializeResponse<TResponse>(response);
    }

    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string ep, TRequest payload)
    {
        var response = await _httpClient.PutAsJsonAsync(ep, payload);
        return await DeserializeResponse<TResponse>(response);
    }

    public async Task<bool> DeleteAsync(string ep, object? parameters = null)
    {
        var url = BuildUrlWithParams(ep, parameters);
        var response = await _httpClient.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }

    private string BuildUrlWithParams(string ep, object? parameters)
    {
        if (parameters == null) return ep;

        var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
        foreach (var prop in parameters.GetType().GetProperties())
        {
            var value = prop.GetValue(parameters)?.ToString();
            if (!string.IsNullOrWhiteSpace(value))
                query[prop.Name] = value;
        }

        return $"{ep}?{query}";
    }

    private static async Task<T?> DeserializeResponse<T>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Status: {response.StatusCode}, Content: {content}");
        }

        return await response.Content.ReadFromJsonAsync<T>();
    }
}

public interface HttpReq
{
    public string? Host { get; set; } // http://www.arab.com/ || environment.API_URL
    public string? Srvc { get; set; } // api/Hierarchy/v1 || environment.API_URL
    public string? Controller { get; set; } // api/Hierarchy/v1 || environment.API_URL
    public string Action { get; set; } // get, gets, get-by-id
    public string? Res { get; set; } //// get-by-id/1

    public object? Query { get; set; } // {id:1, name:Muhammad}
    public string? Param { get; set; } // ?id=1&name=Muhammad

    public object? Body { get; set; } // Specific to CREATE, PATCH, DELETE
}
