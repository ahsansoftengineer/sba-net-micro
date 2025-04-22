
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace GLOB.API.Configz;

public static partial class ExtConfig
{
    public static string GetWebUrl(this IConfiguration configuration)
    {
        string hostName = configuration.GetValueStr("ASPNETCORE_URLS");
        string prefix = configuration.GetValueStr("ASPNETCORE_ROUTE_PREFIX");
        return $"{hostName}/{prefix}";
    }
    public static string GetValueStr(this IConfiguration configuration, string key, string defaultValue = "No Default Value Define in Configuration")
    {
        string result = configuration.GetValue(key, default(string));
        if (result.IsNullOrEmpty())
            return defaultValue;
        else
            return result;
    }
    public static IEnumerable<ErrorModel> ToExtValidationError(this ModelStateDictionary modelState)
    {
        return modelState
            .Where(m => m.Value.Errors.Count > 0)
            .Select(m => new ErrorModel
            {
                Field = m.Key,
                Errors = m.Value.Errors.Select(e => e.ErrorMessage).ToArray(),
            });
    }
}


public class ErrorModel
{
    public string Field { get; set; }
    public IEnumerable<string> Errors { get; set; }
}