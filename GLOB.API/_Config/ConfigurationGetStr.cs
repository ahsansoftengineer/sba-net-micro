
using Microsoft.IdentityModel.Tokens;

namespace GLOB.API.Configz;
public static partial class Ext
{
    public static string GetValueStr(this IConfiguration configuration, string key, string defaultValue = "No Default Value Define in Configuration")
    {
        string result =  configuration.GetValue(key, default(string));
        if(result.IsNullOrEmpty())
            return defaultValue;
        else
            return result;
    }
} 